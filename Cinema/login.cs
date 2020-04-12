using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cinema
{
    public class Login
    {
        public static void loginMain()
        {
            ///Variabelen
            string username;
            string password;
            string tempPassword;

            Dictionary<string, string> login;

            User user = new User()
            {
                username = "",
                password = "",
                privileges = ""
            };
           

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

            Console.WriteLine("[1] Login\n" +
                              "[2] New Account\n" +
                              "[3] Turn off"
                              );
            Console.Write("> ");
            string menuChoice = Console.ReadLine();
          

            ///Het login programmaatje.
            while (true)
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

                        
                        user.privileges = "admin";
                        Console.WriteLine("Your login was succesfull");
                        LogedIn.LogedInAdmin();
