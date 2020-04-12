using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    public class Reserveren
    {
        public static void Reserveer()
        {
            Console.WriteLine("Reserveren gelukt");

            // Send mail to confirm reservation (Once we have that...)
            Database.DatabaseProgram db = new Database.DatabaseProgram();
            db.ConfirmationMail();
            
        }
    }
}
