using System;
using Newtonsoft.Json;
using System.IO;

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
            Login.loginMain();
        }
    }
}
