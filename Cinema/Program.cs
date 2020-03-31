using System;
using System.IO;
using Newtonsoft.Json;

namespace Cinema
{
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
