using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class Contact
    {
        public static void contact()
        {
            string optieContact;


            Console.WriteLine("\n\nWilt u terug naar het menu? (ja of nee)");
            optieContact = Console.ReadLine();
            if (optieContact == "ja")
            {
                Mainmenu.Menu();
            }
            else if (optieContact == "nee")
            {

            }
            else
            {
                Console.WriteLine("\nU heeft niet met ja of nee geantwoord. Probeer het opnieuw.");
                Contact.contact();
            }
        }
    }
}
