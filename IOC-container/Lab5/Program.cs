using Lab5.implamentations;
using Lab5.interfaces;
using pluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var pluginloader = PluginLoader.GetInstance();
            ContainerService containerService = ContainerService.GetInstance();
            pluginloader.LoadPluginContainer();
            IContainer container = containerService.GetContainer(pluginloader.GetListPlugin());
            if (container == null)
            {
                Console.WriteLine("Ошибка получения контейнера");
                Console.ReadLine();
                return;
            }

            var str = "Lord Voldemort";
            container.RegisterInstance<string>(str);
            
            container.RegisterSingleton<IInformer, ConsoleInformer>();
            var informer = container.Resolve<IInformer>();
            var informer2 = container.Resolve<IInformer>();
            if (informer == informer2)
            {
                if (informer.Equals(informer2))
                {
                    Console.WriteLine("Это синглтон");
                }
            }
            informer.Notify();
            Console.WriteLine(new string('-', 42));
            
            container.Register<IIlluminator, MagicWand>();


            var light = container.Resolve<IIlluminator>();
            light.LightUp();
            Console.WriteLine(new string('-', 42));

            var lighter = new MagicWand("Harry");
            container.RegisterInstance<IIlluminator, MagicWand>(lighter);
            light = container.Resolve<IIlluminator>();
            light.LightUp();

            Console.ReadLine();

        }
    }
}

#region INFO
//https://www.outcoldman.com/ru/archive/2011/03/07/%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D1%83%D0%B5%D0%BC-%D1%81%D0%B0%D0%BC%D0%B8-%D0%BF%D1%80%D0%BE%D1%81%D1%82%D0%BE%D0%B9-ioc-%D0%BA%D0%BE%D0%BD%D1%82%D0%B5%D0%B8%D0%BD%D0%B5%D1%80/
#endregion