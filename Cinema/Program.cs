using System;
using System.IO;
using Newtonsoft.Json;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.DatabaseProgram db = new Database.DatabaseProgram();
            db.DatabaseMain();
        }
    }
}
