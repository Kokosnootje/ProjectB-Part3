using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Cinema
{
    public class LogedIn
    {
        public static void LogedInMain()
        {
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\n[1] Films\n[2] Snacks menu\n[3] Contact\n[4] Mijn reserveringen\n[5] Uitloggen");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                /// Movies
                //Geef pagina met films weer
                Console.WriteLine("\nDit is de films pagina");
                // Run films database
                Database.DatabaseProgram db = new Database.DatabaseProgram();
                db.DatabaseShow();

                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInMain();
                }
            }
            else if (menuNumber == "2")
            {
                //Geef pagina met snacks menu weer
                snacksMenu.snacksMenuOpvragen();
            }
            else if (menuNumber == "3")
            {
                //Aanroepen contact.cs
                Contact.contact();
            }
            else if (menuNumber == "4")
            {
                ///Geeft alle gereserveerde films weer
                var login = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(@"admins.json"));
                foreach (string item in login[Variables.username])
                {
                    if (item != login[Variables.username][0])
                    {
                        Console.WriteLine(item);
                    }
                }
            
            }
            else if (menuNumber == "5")
            {
                /// Movies
                Console.WriteLine("Succesvol uitgelogd!");
                Login.loginMain();
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                LogedInMain();
            }

        }
        public static void LogedInAdmin()
        {
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\n[1] Films\n[2] Voeg film toe\n[3] Verwijder film\n[4] Reserveringen\n[5] Voeg reservering toe\n[6] Verwijder reservering\n[7] Log uit");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                /// Movies
                //Geef pagina met films weer
                Console.WriteLine("\nDit is de films pagina");
                // Run database
                Database.DatabaseProgram db = new Database.DatabaseProgram();
                db.DatabaseShow();
            }
            else if (menuNumber == "2")
            {
                // Add movie function
                Console.WriteLine("Op deze pagina kunt u films toevoegen");

                // Film toevoegen

                // Terug naar menu
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "3")
            {
                // Delete movie function
                Console.WriteLine("Op deze pagina kunt u films verwijderen");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "4")
            {
                // Reservations Pagina
                Console.WriteLine("Op deze pagina zijn alle reserveringen te zien");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "5")
            {
                // Reservations Pagina
                Console.WriteLine("Op deze pagina kunt u reserveringen toevoegen");                             
                
                
                
                Console.WriteLine("Druk op ESC om terug te gaan");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }

            }
            else if (menuNumber == "6")
            {
                // Reservations Pagina
                Console.WriteLine("Op deze pagina kunt u reserveringen verwijderen");
                Console.WriteLine("Druk op ESC om terug te gaan");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "7")
            {
                /// Movies
                Console.WriteLine("Succesvol uitgelogd!");
                Login.loginMain();
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                LogedIn.LogedInAdmin();
            }
        }
        }
    }