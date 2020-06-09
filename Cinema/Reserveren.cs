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

                Console.WriteLine("\nWelke dag wilt u naar de film? (gebruik dit format -> 27/05/2020)\n");
                string datum = Console.ReadLine();
                Calendar.showfilms(datum);

                Console.WriteLine("\nWelke film wilt u reserveren?\n");
                string keuze = Console.ReadLine();
                int number = Convert.ToInt32(keuze)-1;

                var calendar = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(File.ReadAllText(@"calendar.json"));

                //haal titel op voor film die gereserveerd wordt
                //werkt nog niet... titel van iedere film op de datum wordt gepakt
                var filmLijst = new List<String>();
                foreach (var zaal in calendar[datum]) 
                {
                   
                    foreach (var films in zaal.Value)
                    {
                        filmLijst.Add(films[0]);
                    }
                }
                string filmNaam = filmLijst[number];

                //Json bestand met films openen en lezen
                JsonSerializer serializer = new JsonSerializer();
                Movies.Movie[] newMovies = JsonConvert.DeserializeObject<Movies.Movie[]>(File.ReadAllText(@"Movies.json"));
                foreach (var item in newMovies)
                {
                    if(item.title == filmNaam)
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

                        //kies stoelen


                        //Keuze om te bevestigen of terug te gaan naar films overzicht
                        Console.WriteLine("\n\n[1] Bevestig reservering\n[2] Breek reservering af\n");
                        int optie = Convert.ToInt32(Console.ReadLine());
                        if(optie == 1)
                        {

                            //Deserialize json file
                            Reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));
                            

                            //Kijk of persoon al bestaat in reserveringen database
                            if (Reserveringen.ContainsKey(Variables.username) == true)
                            {
                                //Indien dit het geval is, voeg nieuwe reservering toe aan persoon            
                                foreach (var zaal in calendar[datum])
                                {
                                    foreach (var films in zaal.Value)
                                    {
                                        if (films[0] == filmNaam)
                                        {
                                            newReservering.Add(item.title);
                                            string Zaal = zaal.Key;
                                            newReservering.Add(Zaal);
                                            newReservering.Add(aantalKaartjes.ToString());
                                            newReservering.Add(films[1]);
                                            newReservering.Add(datum);
                                            Reserveringen[Variables.username].Add(newReservering);
                                        }
                                    }
                                }
                            }
                            
                            //Maak anders persoon aan in database en voeg reservering toe
                            else
                            {
                                foreach (var zaal in calendar[datum])
                                {
                                    foreach (var films in zaal.Value)
                                    {
                                        if (films[0] == filmNaam)
                                        {
                                            newReservering.Add(item.title);
                                            string Zaal = zaal.Key;
                                            newReservering.Add(Zaal);
                                            newReservering.Add(aantalKaartjes.ToString());
                                            newReservering.Add(films[1]);
                                            newReservering.Add(datum);
                                            reserveringen.Add(newReservering);
                                            Reserveringen.Add(Variables.username, reserveringen);
                                        }
                                    }

                                }
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
                            Console.WriteLine("\n\nBedankt voor uw reservering. \nU heeft op " + datum + " de film " + item.title+ " gereserveerd. \nU kunt de reservering vinden bij 'Mijn Reserveringen' in het onderstaande menu. \nOok hebben wij u een bevestigingsmail gestuurd.\n");
                        }

                        if(optie == 2)
                        {
                            // Terug naar menu
                            if (Variables.isLoggedIn)
                                LogedIn.LogedInMain();
                            else
                                Mainmenu.Menu();
                        }

                        if (Variables.isLoggedIn)
                            LogedIn.LogedInMain();
                        else
                            Mainmenu.Menu();
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
                    if (Variables.isLoggedIn)
                        LogedIn.LogedInMain();
                    else
                        Mainmenu.Menu();
                }
            } 
            
            
        }
    }
}
