using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pluginInterface;
using pluginInterface.interfaces;

namespace IOC_container
{
    class PluginContainer : IPluginContainer
    {
        public string ClassName => "IoC-Container";

        public string ID => "1";

        public IContainer GetContainer()
        {
            return new IoC();
        }
    }
}
