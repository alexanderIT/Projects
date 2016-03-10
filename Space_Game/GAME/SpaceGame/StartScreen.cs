using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class StartScreen
    {
        public static void Initialize()
        {
            StreamReader readerLogo = new StreamReader(@"..\..\ExternalFiles\logo.txt");
            using (readerLogo)
            {
                Console.WriteLine(readerLogo.ReadToEnd());
            }

            StreamReader readerSrartMenu = new StreamReader(@"..\..\ExternalFiles\startmenu.txt");
            using (readerSrartMenu)
            {
                Console.WriteLine(readerSrartMenu.ReadToEnd());
            }
        }
    }
}
