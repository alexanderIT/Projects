namespace Game.Common
{
    using System;
    using System.IO;

    using Game;

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
