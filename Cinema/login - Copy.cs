using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Cinema
{
    public class Logintemp
    {
        
        public static void loginMaintemp()
        {
            User user = new User()
            {
                username = "user",
                password = "user",
                privileges = "user"
            };
            User admin = new User()
            {
                username = "admin",
                password = "admin",
                privileges = "admin"
            };
            string login;

            // Write variable "user" to JSON file
            File.WriteAllText(@"users.json", JsonConvert.SerializeObject(user));
            using (StreamWriter file = File.CreateText(@"users.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, user);
            }
            // Write variable "admin" to JSON file
            File.WriteAllText(@"admins.json", JsonConvert.SerializeObject(admin));
            using (StreamWriter file = File.CreateText(@"admins.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, admin);
            }
            Console.WriteLine("(1) Login\n" +
                              "(2) Nieuw account\n" +
                              "(3) Terug"
                              );
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
                var userCheck = JsonConvert.DeserializeObject<Dictionary<string, string>>(login);
                foreach (KeyValuePair<string, string> entry in userCheck)
                {
                    if (entry.Value == user.username && entry.Key == user.password)
                    {
                        user.privileges = "user";
                        Console.WriteLine("You're login was succesfull");
                        LogedIn.LogedInMain();
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
                login = File.ReadAllText(@"admins.json");
                var newAccount = 1;

                ///newAccount.Add("username", user.username);
                Console.WriteLine(newAccount);
            }
            else if (menuChoice == "3")
            {
                Environment.Exit(-1);
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
