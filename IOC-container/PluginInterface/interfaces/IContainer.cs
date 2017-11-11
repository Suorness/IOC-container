using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluginInterface
{
    public interface IContainer
    {
        void Register<TType, TConcrete>() where TConcrete : class, TType;
        void RegisterSingleton<TType, TConcrete>() where TConcrete : class, TType;
        void RegisterInstance<TType, TConcrete>(TConcrete instance) where TConcrete : class, TType;
        TTypeToResolve Resolve<TTypeToResolve>();
        void RegisterSingleton<TType>() where TType : class;
        void RegisterInstance<TType>(TType instance) where TType : class;
        object Resolve(Type type);
    }
}
