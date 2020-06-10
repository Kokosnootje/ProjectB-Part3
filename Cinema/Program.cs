using System;
using System.Collections.Generic;
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

    public class Variables
    {
        public static bool isLoggedIn = false;
        public static string username = "";
        public static int Film = 0;
        public static double totaalPrijs = 0;
        public static bool stoelAvailable = true;
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Zalen.removedStoelen("27/05/2020", "11:00");
            //Calendar.runCalendar();
            //Mainmenu.Menu();
        }
    }
}
