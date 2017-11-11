using pluginInterface;
using pluginInterface.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ContainerService
    {
        public IContainer GetContainer(List<IPluginContainer> PluginList)
        {
            if (PluginList.Count != 0)
            {
                var plugin = PluginList.First();
                return plugin.GetContainer();
            }
            else
            {
                return null;
            }
        }
        private static ContainerService instance = null;
        private ContainerService() { }
        public static ContainerService GetInstance()
        {
            if (instance == null)
            {
                instance = new ContainerService();
            }
            return instance;
        }
    }
}
