using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_container
{
    public class RegisteredObject
    {
        private readonly bool _isSinglton;
        public RegisteredObject(Type concreteType, bool isSingleton, object instance)
        {
            _isSinglton = isSingleton;
            ConcreteType = concreteType;
            SingletonInstance = instance;
            Instance = instance;
        }
        public Type ConcreteType { get; private set; }

        public object SingletonInstance { get; private set; }

        public object Instance { get; private set; }

        public object CreateInstance(params object[] args)
        {
            this.Instance = Activator.CreateInstance(ConcreteType, args);
            if (_isSinglton)
                SingletonInstance = Instance;
            return Instance;
        }
    }
}
