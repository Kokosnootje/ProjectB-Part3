using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class LogedIn
    {
        public static void LogedInMain()
        {
            Console.WriteLine("Type the number where you want to go");
            Console.WriteLine("[1] Home");
            Console.WriteLine("[2] Movies");
            Console.WriteLine("[3] Contact");
            Console.WriteLine("[4] Snacks");
            Console.WriteLine("[5] Log out");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                LogedIn.LogedInMain();
            }
            else if (menuNumber == "2")
            {
                /// Movies
                //Geef pagina met films weer
                Console.WriteLine("\nDit is de films pagina");
                // Run database
                Database.DatabaseProgram db = new Database.DatabaseProgram();
                db.DatabaseMain();
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInMain();
                }
            }
            else if (menuNumber == "3")
            {
                /// Movies
                Console.WriteLine("Contact");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    //Geef contact pagina weer
                    Console.WriteLine("\nDit is de Contact pagina van de bioscoop.\n\nAdres\nWeena 455\n3013AL Rotterdam\n\nOpeningstijden\nma - zo: 10.00 - 22.00\n\nTelefoon\n010-456-13-52");
                    //Aanroepen contact.cs
                    Contact.contact();
                }
                else
                {
                    LogedIn.LogedInMain();
                }

            }
            else if (menuNumber == "4")
            {
                /// Movies
                Console.WriteLine("Snacks");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("\nDit is de snacks menu pagina. Hieronder staan alle snacks met bijbehorende prijzen.");
                }
                else
                {
                    LogedIn.LogedInMain();
                }
            }
            else if (menuNumber == "5")
            {
                /// Movies
                Console.WriteLine("Succesfully loged out");
                Login.loginMain();
            }
            else
            {
                Console.WriteLine("Please enter a valid option!");
                LogedIn.LogedInMain();
            }

        }
        public static void LogedInAdmin()
        {
            Console.WriteLine("Type the number where you want to go");
            Console.WriteLine("[1] Home");
            Console.WriteLine("[2] Movies");
            Console.WriteLine("[3] Add Movie");
            Console.WriteLine("[4] Delete Movie");
            Console.WriteLine("[5] Reservations");
            Console.WriteLine("[6] Add Reservations");
            Console.WriteLine("[7] Delete Reservations");
            Console.WriteLine("[8] Log out");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                LogedIn.LogedInAdmin();
            }
            else if (menuNumber == "2")
            {
                /// Movies
                //Geef pagina met films weer
                Console.WriteLine("\nDit is de films pagina");
                // Run database
                Database.DatabaseProgram db = new Database.DatabaseProgram();
                db.DatabaseMain();
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
                // Add movie function
                Console.WriteLine("On this page you can add a Movie!");
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
                // De;ete movie function
                Console.WriteLine("On this page you can Delete a Movie!");
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
                Console.WriteLine("On this page you can see all the reservations!");
                Console.WriteLine("Press ESC to go to Home");
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
                Console.WriteLine("On this page you can add a reservations!");
                Console.WriteLine("Press ESC to go to Home");
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
                // Reservations Pagina
                Console.WriteLine("On this page you can delete a reservations!");
                Console.WriteLine("Press ESC to go to Home");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "8")
            {
                /// Movies
                Console.WriteLine("Succesfully loged out");
                Login.loginMain();
            }
            else
            {
                Console.WriteLine("Please enter a valid option!");
                LogedIn.LogedInAdmin();
            }
        }
        }
    }