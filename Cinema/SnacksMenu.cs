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
        }
    }

}
