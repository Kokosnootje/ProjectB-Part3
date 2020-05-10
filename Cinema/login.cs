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
            string tempPassword = null;

            Dictionary<string, List<string>> login;

            List<string> userData = new List<string>();

            User user = new User()
            {
                username = "",
                password = "",
                privileges = "",
            };

            ///Het login programmaatje.
            while (true)
            {
                Console.WriteLine("[1] Login\n" +
                                  "[2] Admin Login\n" +
                                  "[3] Nieuw account\n" +
                                  "[4] Terug"
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
                        ///dit stukje maakt het invullen van een wachtwoord "onzichtbaar"
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                            password = password.Remove(password.Length - 1);
                        else if (key.Key != ConsoleKey.Backspace)
                            password += key.KeyChar;
                    }

                    ///Login Check account database for normal users
                    login = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(@"users.json"));
                    foreach (KeyValuePair<string, List<string>> entry in login)
                    {
                        if (entry.Key == username && entry.Value[0] == password)
                        {
                            user.username = entry.Key;
                            user.password = entry.Value[0];
                            user.privileges = "user";
                            Variables.isLoggedIn = true;
                            Variables.username = entry.Key;
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
                        ///dit stukje maakt het invullen van een wachtwoord "onzichtbaar"
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                            password = password.Remove(password.Length - 1);
                        else if (key.Key != ConsoleKey.Backspace)
                            password += key.KeyChar;
                    }

                    ///Login Check account database for admin users
                    var loginAdmin = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"admins.json"));
                    foreach (KeyValuePair<string, string> entry in loginAdmin)
                    {
                        if (entry.Key == username && entry.Value == password)
                        {
                            user.username = entry.Key;
                            user.password = entry.Value;
                            user.privileges = "admin";
                            Console.WriteLine("login was succesvol");
                            LogedIn.LogedInAdmin();
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
                        ///dit stukje maakt het invullen van een wachtwoord "onzichtbaar"
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                            password = password.Remove(password.Length - 1);
                        else if (key.Key != ConsoleKey.Backspace)
                            password += key.KeyChar;
                    }
                    Console.Write("\nRe-enter password\n> ");

                    while (true)
                    {
                        var key = System.Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        if (key.Key == ConsoleKey.Backspace && tempPassword.Length > 0)
                            tempPassword = tempPassword.Remove(tempPassword.Length - 1);
                        else if (key.Key != ConsoleKey.Backspace)
                            tempPassword += key.KeyChar;
                    }

                    if (password == tempPassword)
                    {
                        if (username.Length > 4)
                        {
                            if (password.Length > 4)
                            {
                                if (Regex.IsMatch(username, @"^[a-zA-Z0-9]+$") && Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
                                {
                                    login = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(@"users.json"));
                                    if (login.ContainsKey(username) == false)
                                    {
                                        userData.Add(password);
                                        login.Add(username, userData);
                                        using (StreamWriter file = File.CreateText(@"users.json"))
                                        {
                                            JsonSerializer serializer = new JsonSerializer();
                                            serializer.Serialize(file, login);
                                        }
                                        Console.WriteLine("Account is aangemaakt!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Er bestaat al een account met deze naam!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Gebruikersnaam en wachtwoord mag enkel (hoofd)letters en cijfers bevatten!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wachtwoord moet minimaal 5 karakters lang zijn!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Gebruikersnaam moet minimaal 5 karakters lang zijn!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wachtwoorden komen niet overeen!");
                    }
                }


                else if (menuChoice == "4") ///Exit
                {
                    Mainmenu.Menu();
                }


                else
                {
                    Console.WriteLine("Please pick a valid option!");
                }
            }
        }
    }
}
