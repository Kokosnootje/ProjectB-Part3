using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{

    public class snacksMenu
    {
        public static void snacksMenuOpvragen()
        {
            //Om € teken zichtbaar te maken
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            //Snacksmenu
            Console.WriteLine("\nDit is de snacks menu pagina. Hieronder staan alle snacks met bijbehorende prijzen.\n\n\n");
            Console.WriteLine("Drinken\n\nCola - \u20AC1,95\nFanta - \u20AC1,95\nFristi - \u20AC2,95\n\n\n");
            Console.WriteLine("Popcorn\n\nSmall - \u20AC4,95\nMedium - \u20AC5,95\nLarge - \u20AC7,95\n\n\n");
            Console.WriteLine("Combo Deals\n\nFrisdrank naar keuze & Medium Popcorn - \u20AC6,95");

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
                    Console.WriteLine("\nGelieve een nummer tussen 1 en 4 in te toetsen");
                    Mainmenu.Menu();
                }
            }
            catch
            {
                // Wanneer de input geen int is
                Console.WriteLine("\nEr is geen nummer ingevoerd");
                Mainmenu.Menu();
            }
        }
    }

}
