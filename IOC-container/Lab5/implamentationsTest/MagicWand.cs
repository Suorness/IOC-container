using Lab5.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.implamentations
{
    public class MagicWand : IIlluminator
    {
        public void LightUp()
        {
            Console.WriteLine (hero + " said:" +"Lumos Maxima!!!");
        }
        private string hero = String.Empty;
        public MagicWand(string HeroName)
        {
            hero = HeroName;
        }
    }
}
