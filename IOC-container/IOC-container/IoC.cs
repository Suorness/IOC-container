using pluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IOC_container
{
    public class IoC : IContainer
    {
        private readonly IDictionary<Type, RegisteredObject> _registeredObjects = new Dictionary<Type, RegisteredObject>();

        public void Register<TType, TConcrete>() where TConcrete : class, TType
        {
            Register<TType, TConcrete>(false, null);
        }

        public void RegisterSingleton<TType, TConcrete>() where TConcrete : class, TType
        {
            Register<TType, TConcrete>(true, null);
        }

        public void RegisterInstance<TType, TConcrete>(TConcrete instance) where TConcrete : class, TType
        {
            Register<TType, TConcrete>(true, instance);
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve)ResolveObject(typeof(TTypeToResolve));
        }

        private void Register<TType, TConcrete>(bool isSingleton, TConcrete instance)
        {
            Type type = typeof(TType);
            if (_registeredObjects.ContainsKey(type))
                _registeredObjects.Remove(type);
            _registeredObjects.Add(type, new RegisteredObject(typeof(TConcrete), isSingleton, instance));
        }

        private object ResolveObject(Type type)
        {
            var registeredObject = _registeredObjects[type];
            if (registeredObject == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name));
            }
            return GetInstance(registeredObject);
        }

        //private object GetInstance(RegisteredObject registeredObject)
        //{
        //    object instance = registeredObject.SingletonInstance;
        //    if (instance == null)
        //    {
        //        var parameters = ResolveConstructorParameters(registeredObject);
        //        instance = registeredObject.CreateInstance(parameters.ToArray());
        //    }
        //    return instance;
        //}
        private object GetInstance(RegisteredObject registeredObject)
        {
            object instance = registeredObject.Instance;
            if (instance == null)
            {
                var param = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(param.ToArray());
                instance = registeredObject.Instance;

                foreach (var properti in instance.GetType().GetProperties()) 
                {
                    if (properti.GetCustomAttribute(typeof(LabelAttr)) != null)
                    {
                        var paramType = properti.PropertyType;
                        var obj = ResolveObject(paramType);
                        properti.SetValue(instance, obj);
                    }
                }

                //foreach (var method in instance.GetType().GetMethods())
                //{
                //    if (method.GetCustomAttribute(typeof(LabelAttr)) != null)
                //    {
                //        var args = method.GetParameters();
                //        List<object> list = new List<object>();
                //        foreach (var arg in args)
                //        {
                //            var type = arg.ParameterType;
                //            //var obj = Activator.CreateInstance(type);
                //            var obj = ResolveObject(paramType);
                //            list.Add(obj);

                //        }
                //        method?.Invoke(instance, list.ToArray());
                //    }
                //}

            }
            return instance;
        }
        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
        }

        #region commentcode

        public void RegisterSingleton<TType>() where TType : class
        {
            RegisterSingleton<TType, TType>();
        }
        public void RegisterInstance<TType>(TType instance) where TType : class
        {
            RegisterInstance<TType, TType>(instance);
        }
        public object Resolve(Type type)
        {
            return ResolveObject(type);
        }
        #endregion
    }
}
