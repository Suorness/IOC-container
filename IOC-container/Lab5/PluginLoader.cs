using pluginInterface;
using pluginInterface.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public  class PluginLoader
    {

        public static PluginLoader GetInstance()
        {
            if (instance == null)
            {
                instance = new PluginLoader(); 
            }
            return instance;
        }
                
        private List<IPluginContainer> LoadPlugins()
        {
            var ChangedList = new List<IPluginContainer>();
            string[] pluginNames = null;
            try
            {
                pluginNames = Directory.GetFiles(PluginDir, "*.dll");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            foreach (string pluginName in pluginNames)
            {
                var pluginAssembly = Assembly.LoadFrom(pluginName);
                try
                {
                    foreach (var type in pluginAssembly.GetTypes())
                    {
                        if (type.GetInterfaces().Contains(typeof(IPluginContainer)))
                        {
                            var plugin = Activator.CreateInstance(type) as IPluginContainer;
                            bool isUnique = true;
                            foreach (var item in PluginList)
                            {
                                if (item.ClassName == plugin.ClassName)
                                {
                                    isUnique = false;
                                    break;
                                }
                            }
                            if (isUnique)
                            {
                                PluginList.Add(plugin);
                                ChangedList.Add(plugin);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return (ChangedList);
        }

        public void LoadPluginContainer()
        {
            LoadPlugins();   
        }

        public List<IPluginContainer> GetListPlugin()
        {
            return PluginList;
        }

        private PluginLoader() { }
        private static PluginLoader instance = null    ;
        private List<IPluginContainer> PluginList = new List<IPluginContainer>();
        private string PluginDir = @"..\\..\\..\\IOC-container\\bin\\Debug";
    }
}
