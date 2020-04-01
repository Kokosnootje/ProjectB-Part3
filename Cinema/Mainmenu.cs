using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Mainmenu
    {
        public static void Menu()
        {
            Console.WriteLine("\nKies een van de volgende opties om verder te gaan:\nFilms (=1)\nSnacks menu (=2)\nContact (=3)\nMijn account (=4)");
            int optieMenu1;
            var optieMenu1Placeholder = Console.ReadKey();


            if (char.IsDigit(optieMenu1Placeholder.KeyChar))
            {
                optieMenu1 = int.Parse(optieMenu1Placeholder.KeyChar.ToString());
                if (optieMenu1 == 1)
                {
                    //Geef pagina met films weer
                    Console.WriteLine("\nDit is de films pagina");
                    //Aanroepen films.cs

                }
                else if (optieMenu1 == 2)
                {
                    //Geef pagina met snacks menu weer
                    Console.WriteLine("\nDit is de snacks menu pagina. Hieronder staan alle snacks met bijbehorende prijzen.");
                    //Aanroepen snacksmenu.cs
                }
                else if (optieMenu1 == 3)
                {
                    //Geef contact pagina weer
                    Console.WriteLine("\nDit is de Contact pagina van de bioscoop.\n\nAdres\nWeena 455\n3013AL Rotterdam\n\nOpeningstijden\nma - zo: 10.00 - 22.00\n\nTelefoon\n010-456-13-52");
                    //Aanroepen contact.cs
                    Contact.contact();

                }
                else if (optieMenu1 == 4)
                {
                    //Geef inlog pagina weer
                    Console.WriteLine("\nDit is de account pagina. Heeft u al een account? (ja of nee)");
                    //Aanroepen account.cs       
                }
                else
                {
                    //Wanneer de input niet tussen 1 en 4 ligt
                    Console.WriteLine("\nGelieve een nummer tussen 1 en 4 in te toetsen\n");
                    Mainmenu.Menu();
                }


            }
            else
            {
                //wanneer de input geen int is
                optieMenu1 = -1;
                Console.WriteLine("\n\n\nEr is geen nummer ingevoerd");
                Mainmenu.Menu();
            }
        }
    }
}
