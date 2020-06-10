using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;



namespace Cinema
{
    public class Login
    {


        /// Dit stukkie is om te checken of het email wat ingevoerd is bij het aanmaken van een account wel een valide format heeft: SOURCE https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format

        public class RegexUtilities
        {
            public static bool IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                try
                {
                    // Normalize the domain
                    email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));

                    // Examines the domain part of the email and normalizes it.
                    string DomainMapper(Match match)
                    {
                        // Use IdnMapping class to convert Unicode domain names.
                        var idn = new IdnMapping();

                        // Pull out and process domain name (throws ArgumentException on invalid)
                        var domainName = idn.GetAscii(match.Groups[2].Value);

                        return match.Groups[1].Value + domainName;
                    }
                }
                catch (RegexMatchTimeoutException e)
                {
                    return false;
                }
                catch (ArgumentException e)
                {
                    return false;
                }

                try
                {
                    return Regex.IsMatch(email,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }
        }
        public static void loginMain()
        {
            ///Variabelen
            string username;
            string password;
            string tempPassword = null;

            Dictionary<string, string> login;

            User user = new User()
            {
                username = "",
                password = "",
                privileges = "",
            };

            Variables.isLoggedIn = true;
            Console.WriteLine(Variables.isLoggedIn);
            ///Het login programmaatje.
            while (true)
            {
                Console.WriteLine("\n[1] Login\n" +
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
                    login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"users.json"));
                    foreach (KeyValuePair<string, string> entry in login)
                    {
                        if (entry.Key == username && entry.Value == password)
                        {
                            user.username = entry.Key;
                            user.password = entry.Value;
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
                    Console.Write("Gebruikersnaam\n> ");
                    username = Console.ReadLine();
                    Console.Write("Wachtwoord\n> ");
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
                    username = "";
                    password = "";
                    var emailval = false;
                    login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"users.json"));
                    
                        while (true)
                    {

                        while (!emailval)
                        {
                            Console.WriteLine("\nVoer een geldig emailadres in. (voer enkel een 'q' in om te annuleren)");
                            Console.Write("\nGebruikersnaam\n> ");
                            username = Console.ReadLine();
                            if (username == "q")
                            {
                                Mainmenu.Menu();
                            }
                            Console.Write("\nVoer gebruikersnaam nogmaals in\n> ");
                            var tempUsername = Console.ReadLine();
                            if (RegexUtilities.IsValidEmail(username) && username == tempUsername)
                                emailval = true;
                            else if (login.ContainsKey(username) == false)
                            {
                                Console.WriteLine("Dit account bestaat al!");
                            }
                            else if (!RegexUtilities.IsValidEmail(username))
                            {
                                Console.WriteLine($"Dit is geen valide email adres: {username}\n");
                            }
                            else
                                Console.WriteLine("de ingevoerde gebruikersnamen komen niet overeen");
                        }

                        Console.Write("\nWachtwoord\n> ");
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
                        Console.Write("\nVoer wachtwoord nogmaals in\n> ");

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
                            if (password.Length > 4)
                            {
                                login = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"users.json"));
                                if (login.ContainsKey(username) == false)
                                {
                                    login.Add(username, password);
                                    using (StreamWriter file = File.CreateText(@"users.json"))
                                    {
                                        JsonSerializer serializer = new JsonSerializer();
                                        serializer.Serialize(file, login);
                                    }
                                    Console.WriteLine("\nAccount is aangemaakt!\n");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nEr bestaat al een account met deze naam!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nWachtwoord moet minimaal 5 karakters lang zijn!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWachtwoorden komen niet overeen!");
                        }
                    }
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
