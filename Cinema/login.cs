﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

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
           


            ///Het login programmaatje.
            while (true)
            {
                Console.WriteLine("\n(1) Login\n" +
                                  "(2) Admin Login\n" +
                                  "(3) Nieuw account\n" +
                                  "(4) Terug"
                                  );
                Console.Write("> ");
                string menuChoice = Console.ReadLine();

                if (menuChoice == "1") ///Login
                {
                    Console.Write("Username\n> ");
                    username = Console.ReadLine();
                    Console.Write("Password\n> ");
                    System.Console.Write("password: ");
                    password = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        password += key.KeyChar;
                    }

                    ///Login Check account database for normal users
                    login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"users.json"));
                    foreach (KeyValuePair<string, string> entry in login)
                    {
                        if (entry.Key == username && entry.Value == password)
                        {
                            user.username = entry.Key;
                            user.password = entry.Value;
                            user.privileges = "user";
                            Console.WriteLine("login was succesvol");
                            LogedIn.LogedInMain();
                        }
                    }
                }


                else if (menuChoice == "2") ///Admin Login
                {
                    Console.Write("Username\n> ");
                    username = Console.ReadLine();
                    Console.Write("Password\n> ");
                    password = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        password += key.KeyChar;
                    }

                    ///Login Check account database for admin users
                    login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"admins.json"));
                    foreach (KeyValuePair<string, string> entry in login)
                    {
                        if (entry.Key == username && entry.Value == password)
                        {
                            user.username = entry.Key;
                            user.password = entry.Value;
                            user.privileges = "admin";
                            Console.WriteLine("login was succesvol");
                            LogedIn.LogedInMain();
                        }
                    }
                }


                else if (menuChoice == "3") ///Nieuw Account
                {
                    Console.Write("Username\n> ");
                    username = Console.ReadLine();
                    Console.Write("Password\n> ");
                    password = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        password += key.KeyChar;
                    }
                    Console.Write("\nRe-enter password\n> ");
                    tempPassword = null;
                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        tempPassword += key.KeyChar;
                    }
                    if (password == tempPassword)
                    {
                        login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"admins.json"));
                        login.Add(username, password);
                        using (StreamWriter file = File.CreateText(@"users.json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, login);
                        }
                        Console.WriteLine("Account is aangemaakt!");
                    }
                    else { Console.WriteLine("Wachtwoorden komen niet overeen!"); }
                }


                else if (menuChoice == "4") ///Exit
                {
                    ///Environment.Exit(-1);
                    return;
                }


                else
                {
                    Console.WriteLine("Please pick a valid option!");
                }
            }
        }
    }
}
