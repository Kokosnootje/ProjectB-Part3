using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cinema
{
    public class Reserveren
    {
        public static void Reserveer()
        {
            //Check of user is ingelogd
            if (Variables.isLoggedIn)
            {
                Console.WriteLine("\nU bent ingelogd en kunt reserveren\n\n");
                
                //Json bestand met films openen en lezen
                JsonSerializer serializer = new JsonSerializer();
                Database.Movie[] newMovies = JsonConvert.DeserializeObject<Database.Movie[]>(File.ReadAllText(@"Database.json"));
                foreach (var item in newMovies)
                {
                    if(item.id == Variables.Film)
                    {
                        //aantal kaartjes vaststellen
                        Console.WriteLine("Hoeveel kaartjes wilt u bestellen voor de film " + item.title + "?\n");
                        int aantalKaartjes = Convert.ToInt32(Console.ReadLine());

                        //totaalprijs berekenen
                        double totaalPrijs = aantalKaartjes * item.price;
                        Variables.totaalPrijs = totaalPrijs;

                        //Om € teken zichtbaar te maken
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.WriteLine("\n\nDe totaalprijs bedraagt \u20AC" + totaalPrijs);

                        //Keuze om te bevestigen of terug te gaan naar films overzicht
                        Console.WriteLine("\n\n[1] Bevestig reservering\n[2] Breek reservering af");
                        int optie = Convert.ToInt32(Console.ReadLine());
                        if(optie == 1)
                        {
                            Console.WriteLine("\n\nBedankt voor uw reservering. Wij hebben u een bevestigingsmail gestuurd.\n");
                            // Send mail to confirm reservation
                            Database.DatabaseProgram db = new Database.DatabaseProgram();
                            // db.ConfirmationMail();
                        }
                        if(optie == 2)
                        {
                            // Terug naar menu
                            if (Variables.isLoggedIn)
                                LogedIn.LogedInMain();
                            else
                                Mainmenu.Menu();
                        }

                    }
                }
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
