using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Mainmenu
    {
        public static void Menu()
        {
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\n[1] Films\n[2] Snacks menu\n[3] Contact\n[4] Mijn account");
            Console.Write("> ");
            string optieMenu = Console.ReadLine();

            try
            {
                int.Parse(optieMenu);
                if (optieMenu == "1")
                {
                    bool tempMenu = true;
                    while (tempMenu == true)
                    {
                        Console.Clear();
                        // Run database
                        Movies.MovieProgram db = new Movies.MovieProgram();
                        //Films menu
                        Console.WriteLine("\n[1] Alle films bekijken\n[2] Film zoeken\n[3] Ga terug");
                        Console.Write("> ");
                        optieMenu = Console.ReadLine();

                        if (optieMenu == "1")
                        {
                            Console.Clear();
                            //Geef pagina met films weer
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
                              Reserveren.Reserveer();
                            }
                            else if (optieMenu3 == "3")
                            {
                                Mainmenu.Menu();
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
                            Mainmenu.Menu();
                        }
                        
                    }
                }
                else if (optieMenu == "2")
                {
                    Console.Clear();
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
                            Console.Clear();
                            Mainmenu.Menu();
                        }
                        else if (optieSnacksMenu == "2")
                        {
                            // Exit
                        }
                        else
                        {
                            Console.Clear();
                            // Wanneer de input niet tussen 1 en 4 ligt
                            Console.WriteLine("\nGelieve een nummer tussen 1 en 2 in te toetsen");
                            snackdb.SnacksShow();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        // Wanneer de input geen int is
                        Console.WriteLine("\nEr is iets fout gegaan. Probeer opnieuw.");
                        snackdb.SnacksShow();
                    }
                }
                else if (optieMenu == "3")
                {
                    Console.Clear();
                    //Aanroepen contact.cs
                    Contact.contact();
                }
                else if (optieMenu == "4")
                {
                    Console.Clear();
                    //Geef inlog pagina weer
                    Console.WriteLine("\nDit is de account pagina. Kies een van de volgende opties:");
                    Login.loginMain();
                    //Aanroepen account.cs
                }
                else
                {
                    Console.Clear();
                    //Wanneer de input niet tussen 1 en 4 ligt
                    Console.WriteLine("\nGelieve een nummer tussen 1 en 4 in te toetsen");
                    Mainmenu.Menu();
                }
            }
            catch(Exception e)
            {
                // HAAL DIT WEG ZODRA APP KLAAR IS!
                Console.WriteLine(e);

                // Wanneer er iets ingevoerd word wat niet klopt.
                Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.");
                Mainmenu.Menu();
            }
        }
    }
}
