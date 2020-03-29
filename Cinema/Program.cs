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
            User user = new User()
            {
                username = "temp",
                password = "temp",
                privileges = "temp"
            };
            string login;


            Console.WriteLine("Welkom in mijn login test ding :D <3");
            Console.WriteLine("(1) Login\n" +
                              "(2) New Account");
            Console.Write("> ");
            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                Console.WriteLine("Fill in Username and Password");
                Console.Write("Username: ");
                user.username = Console.ReadLine();
                Console.Write("Password: ");
                user.password = Console.ReadLine();

                login = File.ReadAllText(@"users.json");
                User userCheck = JsonConvert.DeserializeObject<User>(login);
                if (userCheck.username == user.username && userCheck.password == user.password)
                {
                    Console.WriteLine("SUCCES> User");
                    user.privileges = "user";
                }
                else
                {
                    login = File.ReadAllText(@"admins.json");
                    userCheck = JsonConvert.DeserializeObject<User>(login);
                    if (userCheck.username == user.username && userCheck.password == user.password)
                    {
                        Console.WriteLine("SUCCES> Admin");
                        user.privileges = "admin";
                    }
                    else
                    {
                        Console.WriteLine("Failed to login");
                    }
                }
            }
            else if (menuChoice == "2")
            {
                Console.WriteLine("Fill in Username and Password");
                Console.Write("Username: ");
                user.username = Console.ReadLine();
                Console.Write("Password: ");
                user.password = Console.ReadLine();
                Console.WriteLine("Re-enter password");
                Console.Write("Password: ");
                string validate = Console.ReadLine();
                if (user.password == validate)
                {
                    user.privileges = "user";

                }
            }
            else
            {
                Console.WriteLine("Please pick a valid option!");
            }






            ///MISSCHIEN OOIT NOG NODIG VOOR ANDERE DINGEN ;)
            ///string login = JsonConvert.SerializeObject(user);

            ///File.WriteAllText(@"login.json", login);

            ///Console.WriteLine("stored!");
        }
    }
}
