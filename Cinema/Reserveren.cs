using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Reserveren
    {
        public static void Reserveer()
        {

            if (variables.isLoggedIn)
            {
                Console.WriteLine("u reserveert fil nummer" + variables.Film);
                Console.WriteLine("Reserveren gelukt");
                // Send mail to confirm reservation
                Database.DatabaseProgram db = new Database.DatabaseProgram();
                //db.ConfirmationMail();
            }
            else
            {
                Console.WriteLine("U bent niet ingelogd\n");
                Console.WriteLine("Press ESC to go to login\n");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                }
                else
                {
                    Login.loginMain();
                }
            }
            
            
        }
    }
}
