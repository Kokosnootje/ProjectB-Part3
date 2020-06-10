using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
                    Console.WriteLine("\n[1] Alle films bekijken\n[2] Film zoeken\n[3] Ga terug");
                    Console.Write("> ");
                    optieMenu = Console.ReadLine();

                    if (optieMenu == "1")
                    {
                        //Geef pagina met films weer
                        Console.Clear();
                        db.MovieShow();
                        Console.WriteLine("\n\nKies een van de volgende opties:\n[1] Film bekijken\n[2] Film reserveren\n[3] Ga terug");
                        string optieMenu3 = Console.ReadLine();
                        if (optieMenu3 == "1")
                        {
                            Console.Clear();
                            db.pickMovie();
                        }
                        else if (optieMenu3 == "2")
                        {
                            Console.Clear();
                            Reserveren.Reserveer();
                        }
                        else if (optieMenu3 == "3")
                        {
                            Console.Clear();
                            LogedIn.LogedInMain();
                        }
                    }

                    else if (optieMenu == "2")
                    {
                        Console.Clear();
                        db.filterMovie();
                    }


                    else if (optieMenu == "3")
                    {
                        Console.Clear();
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
                            Console.Clear();
                            Mainmenu.Menu();
                    }
                    else if (optieSnacksMenu == "2")
                    {
                        // Exit
                    }
                    else
                    {
                        // Wanneer de input niet tussen 1 en 4 ligt
                        Console.Clear();
                        Console.WriteLine("\nGelieve een nummer tussen 1 en 2 in te toetsen");
                        snackdb.SnacksShow();
                    }
                }
                catch
                {
                    // Wanneer de input geen int is
                    Console.Clear();
                    Console.WriteLine("\nEr is iets fout gegaan. Probeer opnieuw.");
                    snackdb.SnacksShow();
                }

            }
            else if (optieMenu == "3")
            {
                //Aanroepen contact.cs
                Console.Clear();
                Contact.contact();
            }
            else if (optieMenu == "4")
            {
                ///Geeft alle gereserveerde films weer
                var reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));
                foreach (var item in reserveringen[Variables.username])
                {
                    Console.WriteLine("\n"+item[0]);
                    Console.WriteLine("====================");
                    Console.WriteLine("Film: "+item[0]);
                    Console.WriteLine("Theaterzaal: " + item[1]);
                    Console.WriteLine("Aantal kaartjes: " + item[2]);
                    Console.WriteLine("Starttijd: " + item[3]);
                    Console.WriteLine("Datum: " + item[4]);
                    int counter = 5;
                    string str = "Stoelen: ";
                    while (item.Count > counter)
                    {
                        str += (item[counter] + " ");
                        counter += 1;
                    }
                    Console.WriteLine(str);
                    

                    Console.WriteLine("\n");
                }
                LogedInMain();
            
            }
            else if (optieMenu == "5")
            {
                /// Movies
                Console.Clear();
                Console.WriteLine("Succesvol uitgelogd!");
                Login.loginMain();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                LogedInMain();
            }

        }
        public static void LogedInAdmin()
        {
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\n[1] Films\n[2] Voeg film toe\n[3] Plan film in\n[4] Verwijder film\n[5] Reserveringen\n[6] Voeg reservering toe\n[7] Verwijder reservering\n[8] Snack toevoegen\n[9] Snack verwijderen\n[10] Log uit");
            Console.Write("> ");
            string menuNumber = Console.ReadLine();
            if (menuNumber == "1")
            {
                /// Movies
                //Geef pagina met films weer
                Console.Clear();
                Console.WriteLine("\nDit is de films pagina");
                // Run database
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.MovieShow();
                Console.WriteLine("\n\nKies een van de volgende opties:\n[1] Film bekijken\n[2] Ga terug");
                string optieMenu3 = Console.ReadLine();
                if (optieMenu3 == "1")
                {
                    Console.Clear();
                    db.pickMovie();
                }
                else if (optieMenu3 == "2")
                {
                    Console.Clear();
                    LogedIn.LogedInAdmin();
                }
            }
            else if (menuNumber == "2")
            {
                // Add movie function
                Console.WriteLine("Op deze pagina kunt u films toevoegen");
                Console.Clear();
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.addMovie();
                              
                LogedIn.LogedInAdmin();
                
            }
            else if (menuNumber == "3")
            {
                Console.Clear();
                // Assign movie
                Console.WriteLine("Op deze pagina kunt u films inplannen");
                Movies.MovieProgram db = new Movies.MovieProgram();
                db.schedualMovie();

                LogedIn.LogedInAdmin();
            }
            else if (menuNumber == "4")
            {
                // Delete movie function
                Console.Clear();
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
            else if (menuNumber == "5")
            {
                // Reservations Pagina
                Console.Clear();
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
            else if (menuNumber == "6")
            {
                Console.Clear();
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
            else if (menuNumber == "7")
            {
                Console.Clear();
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
            else if (menuNumber == "8")
            {
                Console.Clear();
                Snacks.SnacksProgram snackdb = new Snacks.SnacksProgram();
                snackdb.addSnack();
                LogedIn.LogedInAdmin();
            }
            else if (menuNumber == "9")
            {
                Console.Clear();
                Snacks.SnacksProgram snackdb = new Snacks.SnacksProgram();
                snackdb.deleteSnack();
                LogedIn.LogedInAdmin();
            }
            else if (menuNumber == "10")
            {
                Console.Clear();
                Console.WriteLine("Succesvol uitgelogd!");
                Login.loginMain();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                LogedIn.LogedInAdmin();
            }
        }
        }
    }