using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Cinema
{
    public class Reserveren
    {      
        public static void Reserveer()
        {
            Dictionary<string, List<List<string>>> Reserveringen;
            List<List<string>> reserveringen = new List<List<string>>();
            List<string> newReservering = new List<string>();

            //Check of user is ingelogd
            if (Variables.isLoggedIn)
            {
                Console.WriteLine("\nU bent ingelogd en kunt reserveren\n\n");
                
                //Json bestand met films openen en lezen
                JsonSerializer serializer = new JsonSerializer();
                Movies.Movie[] newMovies = JsonConvert.DeserializeObject<Movies.Movie[]>(File.ReadAllText(@"Movies.json"));
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
                        Console.WriteLine("\n\n[1] Bevestig reservering\n[2] Breek reservering af\n");
                        int optie = Convert.ToInt32(Console.ReadLine());
                        if(optie == 1)
                        {

                            //Deserialize json file
                            Reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));
                            string[] dagen = { "Zondag", "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag"};
                            List<string> dagenWeek = new List<string>(dagen);
                            int huidigeDag = ((int)System.DateTime.Now.DayOfWeek);

                            //Dag kiezen om te reserveren
                            Console.WriteLine("\nKies een van de volgende dagen om te reserveren: "+ dagenWeek[huidigeDag+1] + " [1] " + dagenWeek[huidigeDag + 2] + " [2] " + dagenWeek[huidigeDag + 3] + " [3] \n\n");
                            int day = Convert.ToInt32(Console.ReadLine());

                            //Kijk of persoon al bestaat in reserveringen database
                            if (Reserveringen.ContainsKey(Variables.username) == true)
                            {
                                //Indien dit het geval is, voeg nieuwe reservering toe aan persoon
                                newReservering.Add(item.title);
                                //newReservering.Add((item.theatreNumber).ToString());
                                newReservering.Add(aantalKaartjes.ToString());
                                //newReservering.Add(item.startTime.ToString());
                                newReservering.Add(dagenWeek[day]);
                                Reserveringen[Variables.username].Add(newReservering);
                            }
                            
                            //Maak anders persoon aan in database en voeg reservering toe
                            else
                            {
                                newReservering.Add(item.title);
                                //newReservering.Add((item.theatreNumber).ToString());
                                newReservering.Add(aantalKaartjes.ToString());
                                //newReservering.Add(item.startTime.ToString());
                                reserveringen.Add(newReservering);
                                newReservering.Add(dagenWeek[day]);
                                Reserveringen.Add(Variables.username, reserveringen);
                            }

                            //Schrijf terug naar json file
                            using (StreamWriter file = File.CreateText(@"Reserveringen.json"))
                            {
                                JsonSerializer serialize = new JsonSerializer();
                                serialize.Serialize(file, Reserveringen);
                            }

                            // Send mail to confirm reservation
                            Movies.MovieProgram db = new Movies.MovieProgram();
                            // db.ConfirmationMail();
                            Console.WriteLine("\n\nBedankt voor uw reservering. U heeft op " + dagenWeek[day] + " de film " + item.title+ /*" gereserveerd om " + item.startTime + */". U kunt de reservering vinden bij 'Mijn Reserveringen' in het onderstaande menu. Ook hebben wij u een bevestigingsmail gestuurd.\n");
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
                Console.WriteLine("Druk op ESC om in te loggen\n");
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
