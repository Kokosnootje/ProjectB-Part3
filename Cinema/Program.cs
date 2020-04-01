using System;
using System.IO;
using Newtonsoft.Json;

namespace Cinema
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string privileges { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Mainmenu koppelen
            Mainmenu.Menu();

            Database.DatabaseProgram db = new Database.DatabaseProgram();
            db.DatabaseMain();
        }
    }
}
