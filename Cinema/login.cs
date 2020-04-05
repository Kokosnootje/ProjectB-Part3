using System;
using Newtonsoft.Json;
using System.IO;

namespace Cinema
{
    public class Login
    {
        public static void loginMain()
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
                              "(2) New Account\n" +
                              "(3) Turn off"
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
                User userCheck = JsonConvert.DeserializeObject<User>(login);
                if (userCheck.username == user.username && userCheck.password == user.password)
                {
                    user.privileges = "user";
                    Console.WriteLine("Your login was succesfull");
                    LogedIn.LogedInMain();
                }
                else
                {
                    login = File.ReadAllText(@"admins.json");
                    userCheck = JsonConvert.DeserializeObject<User>(login);
                    if (userCheck.username == user.username && userCheck.password == user.password)
                    {
                        
                        user.privileges = "admin";
                        Console.WriteLine("Your login was succesfull");
                        LogedIn.LogedInAdmin();
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
