﻿using System;
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
            string optieMenu = Console.ReadLine();
            if (optieMenu == "1")
            {
                {

                    // Run database
                    Movies.MovieProgram db = new Movies.MovieProgram();
                    //Films menu
                    Console.WriteLine("\n[1] alle films bekijken\n[2] Film zoeken\n[3] Ga terug");
                    Console.Write("> ");
                    optieMenu = Console.ReadLine();

                    if (optieMenu == "1")
                    {
                        //Geef pagina met films weer
                        db.MovieShow();
                        db.pickMovie();
                    }

                    else if (optieMenu == "2")
                    {
                        db.filterMovie();
                    }


                    else if (optieMenu == "3")
                    {
                        LogedIn.LogedInMain();
                    }
                }
            }
            else if (optieMenu == "2")
            {
                //Geef pagina met snacks menu weer
                Snacks.SnacksProgram snackdb = new Snacks.SnacksProgram();
                snackdb.SnacksShow();
                string optieSnacksMenu;
                Console.WriteLine("\n\nWilt u terug naar het menu?\n[1] Ja\n[2] Nee");
                optieSnacksMenu = Console.ReadLine();
                try
                {
                    if (optieSnacksMenu == "1")
                    {
                        // Terug naar menu
                        if (Variables.isLoggedIn)
                            LogedIn.LogedInMain();
                        else
                            Mainmenu.Menu();
                    }
                    else if (optieSnacksMenu == "2")
                    {
                        // Exit
                    }
                    else
                    {
                        // Wanneer de input niet tussen 1 en 4 ligt
                        Console.WriteLine("\nGelieve een nummer tussen 1 en 2 in te toetsen");
                        snackdb.SnacksShow();
                    }
                }
                catch
                {
                    // Wanneer de input geen int is
                    Console.WriteLine("\nEr is iets fout gegaan. Probeer opnieuw.");
                    snackdb.SnacksShow();
                }

            }
            else if (optieMenu == "3")
            {
                //Aanroepen contact.cs
                Contact.contact();
            }
            else if (optieMenu == "4")
            {
                ///Geeft alle gereserveerde films weer
                var reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));
                foreach (var item in reserveringen[Variables.username])
                {
                    Console.WriteLine(item[0]);
                }
                LogedInMain();
            
            }
            else if (optieMenu == "5")
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
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\n[1] Films\n[2] Voeg film toe\n[3] Verwijder film\n[4] Reserveringen\n[5] Voeg reservering toe\n[6] Verwijder reservering\n[7] Snack toevoegen\n[8] Log uit");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                /// Movies
                //Geef pagina met films weer
                Console.WriteLine("\nDit is de films pagina");
                // Run database
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.MovieShow();
            }
            else if (menuNumber == "2")
            {
                // Add movie function
                Console.WriteLine("Op deze pagina kunt u films toevoegen");
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.addMovie();
                              
                LogedIn.LogedInAdmin();
                
            }
            else if (menuNumber == "3")
            {
                // Delete movie function
                Console.WriteLine("Op deze pagina kunt u films verwijderen");
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.deleteMovie();

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
                Snacks.SnacksProgram snackdb = new Snacks.SnacksProgram();
                snackdb.addSnack();
            }
            else if (menuNumber == "8")
            {
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