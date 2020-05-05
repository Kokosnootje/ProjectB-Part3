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
                    //Geef pagina met films weer
                    Console.WriteLine("\nDit is de films pagina");
                    // Run database
                    Movies.MovieProgram db = new Movies.MovieProgram();
                    db.MovieShow();
                    //Aanroepen films.cs

                }
                else if (optieMenu == "2")
                {
                    //Geef pagina met snacks menu weer
                    snacksMenu.snacksMenuOpvragen();
                }
                else if (optieMenu == "3")
                {
                    //Aanroepen contact.cs
                    Contact.contact();
                }
                else if (optieMenu == "4")
                {
                    //Geef inlog pagina weer
                    Console.WriteLine("\nDit is de account pagina.");
                    Login.loginMain();
                    //Aanroepen account.cs
                }
                else
                {
                    //Wanneer de input niet tussen 1 en 4 ligt
                    Console.WriteLine("\nGelieve een nummer tussen 1 en 4 in te toetsen");
                    Mainmenu.Menu();
                }
            }
            catch
            {
                // Wanneer er iets ingevoerd word wat niet klopt.
                Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.");
                Mainmenu.Menu();
            }
        }
    }
}
