using IOC_container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.implamentations
{
    public class ConsoleInformer : IInformer
    {
        
        public void Notify()
        {
            Console.WriteLine("This was done by Vasya! " + Info);
        }

        [LabelAttr]
        public string Info { get; set; }

    }
}
