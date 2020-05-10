using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Contact
    {
        public static void contact()
        {
            // Geef contact info weer
            Console.WriteLine("\nDit is de Contact pagina van de bioscoop.\n\nAdres\nWeena 455\n3013AL Rotterdam\n\nOpeningstijden\nma - zo: 10.00 - 22.00\n\nTelefoon\n010-456-13-52");

            // Kijk of gebruiker terug wilt naar het menu
            string optieContact;
            Console.WriteLine("\n\nKies een van de volgende opties:\n[1] Terug");
            optieContact = Console.ReadLine();
            try
            {
                if (optieContact == "1")
                {
                    // Terug naar menu
                    if (Variables.isLoggedIn)
                        LogedIn.LogedInMain();
                    else
                        Mainmenu.Menu();
                }
                else
                {
                    // Wanneer de input niet tussen 1 en 4 ligt
                    Console.WriteLine("\nGelieve een geldig nummer in te toetsen.");
                    contact();
                }
            }
            catch
            {
                // Wanneer de input geen int is
                Console.WriteLine("\nEr ging iets fout. Probeer opnieuw.");
                contact();
            }
         }
    }
}
