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
                username = "temp",
                password = "temp",
                privileges = "temp"
            };
            string login;

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
                    Console.WriteLine("You're login was succesfull");
                    LogedIn.LogedInMain();
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
