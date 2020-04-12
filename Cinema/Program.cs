using System;
using System.IO;
using Newtonsoft.Json;

namespace Cinema
{
    
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string privileges { get; set; }
    }

    public class variables
    {
        public static bool isLoggedIn = false;
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Mainmenu koppelen
            Mainmenu.Menu();
        }
    }
}
