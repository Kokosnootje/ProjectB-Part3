using System;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Generic;

namespace Cinema
{
    public class Database
    {
        public class Movie
        {
            public int id { get; set; }
            public string title { get; set; }
            public string genre { get; set; }
            public TimeSpan duration { get; set; }
            public string language { get; set; }
            public int theatreNumber { get; set; }
            public DateTime startTime { get; set; }
            public string rating { get; set; }
            public double price { get; set; }
        }

        public class DatabaseProgram
        {
            public void DatabaseMain()
            {
                // Will eventually change to user input, currently manual variable of the database
                Movie[] movies = new Movie[]
                {
                new Movie
                {
                    id = 1,
                    title = "Blade",
                    genre = "Action",
                    duration = TimeSpan.Parse("1:30:00"),
                    language = "English",
                    theatreNumber = 1,
                    startTime = DateTime.Parse("13:00:00 PM"),
                    rating = "PG13",
                    price = 19.99
                },
                new Movie
                {
                    id = 2,
                    title = "Lord of the Rings",
                    genre = "Adventure",
                    duration = TimeSpan.Parse("2:30:00"),
                    language = "English",
                    theatreNumber = 2,
                    startTime = DateTime.Parse("14:00:00 PM"),
                    rating = "PG13",
                    price = 19.99
                },
                new Movie
                {
                    id = 3,
                    title = "Alladdin",
                    genre = "Adventure",
                    duration = TimeSpan.Parse("1:45:00"),
                    language = "Dutch",
                    theatreNumber = 1,
                    startTime = DateTime.Parse("14:30"),
                    rating = "E",
                    price = 19.99
                },
                new Movie
                {
                    id = 4,
                    title = "IT",
                    genre = "Horror",
                    duration = TimeSpan.Parse("2:00:00"),
                    language = "English",
                    theatreNumber = 3,
                    startTime = DateTime.Parse("09:00"),
                    rating = "PG13",
                    price = 19.99
                },
                new Movie
                {
                    id = 5,
                    title = "Deadpool",
                    genre = "Action",
                    duration = TimeSpan.Parse("1:30:00"),
                    language = "English (Dutch Subtitles)",
                    theatreNumber = 1,
                    startTime = DateTime.Parse("19:00"),
                    rating = "R",
                    price = 24.99
                },
                new Movie
                {
                    id = 6,
                    title = "The Lion King",
                    genre = "Cartoon",
                    duration = TimeSpan.Parse("1:15:00"),
                    language = "Dutch",
                    theatreNumber = 2,
                    startTime = DateTime.Parse("10:00"),
                    rating = "E",
                    price = 09.99
                }
                };

                // Write the "movies" variable to a JSON file

                File.WriteAllText(@"Database.json", JsonConvert.SerializeObject(movies));
                using (StreamWriter file = File.CreateText(@"Database.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, movies);
                }
            }
            public void DatabaseShow()
            {
                // Update JSON file with most recent data
                DatabaseMain();
                bool choosingMovie = true;
                while (choosingMovie)
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Movie[] newMovies = JsonConvert.DeserializeObject<Movie[]>(File.ReadAllText(@"Database.json"));
                    foreach (var item in newMovies)
                    {
                        Console.WriteLine("[" + item.id + "] " + "Title: " + item.title + " || " + "Genre: " + item.genre);
                    }
                    Console.WriteLine("[" + (newMovies.Length + 1) + "] Ga terug naar het hoofdmenu");
                
                    //Kiezen om een film verder te bekijken
                    Console.WriteLine("\nWelke film wilt u bekijken?");
                
                    try
                    {
                        int menuNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (menuNumber == newMovies.Length)
                        {
                            choosingMovie = false;
                            // Terug naar menu
                            if (Variables.isLoggedIn)
                                LogedIn.LogedInMain();
                            else
                                Mainmenu.Menu();
                        }
                        else
                        {
                            //Alles weergeven van gekozen film
                            Console.WriteLine("\nTitle: " + newMovies[menuNumber].title + "\nGenre: " + newMovies[menuNumber].genre + "\nDuration: " + newMovies[menuNumber].duration + "\nLanguage: " + newMovies[menuNumber].language + "\nTheatre Number: " + newMovies[menuNumber].theatreNumber + "\nStart Time: " + newMovies[menuNumber].startTime + "\nRating: " + newMovies[menuNumber].rating + "\nPrice: " + newMovies[menuNumber].price);
                            Variables.Film = menuNumber + 1;

                            //Menu voor verdere keuzes zoals reserveren
                            Console.WriteLine("\nWat wilt u nu doen?\n[1] Film (" + newMovies[menuNumber].title + ") reserveren\n[2] Kies een andere film");
                            string filmMenuNumber = Console.ReadLine();
                            if (filmMenuNumber == "1")
                            {
                                Reserveren.Reserveer();
                            }
                            else if (filmMenuNumber == "2")
                            {
                                Console.WriteLine("\n");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.\n");
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.\n");
                    }
                }
            }

            public void ConfirmationMail()
            {
                // Server settings
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mailcinemaconfirmation@gmail.com", "ProjectB");

                // Mail reciever and the body of the mail
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mailcinemaconfirmation@gmail.com");
                mail.To.Add("jaspervangent@ziggo.nl");
                mail.Subject = "Reservering bevestiging";

                //Json bestand met films openen en lezen
                JsonSerializer serializer = new JsonSerializer();
                Database.Movie[] newMovies = JsonConvert.DeserializeObject<Database.Movie[]>(File.ReadAllText(@"Database.json"));
                foreach (var item in newMovies)
                {
                    if (item.id == Variables.Film)
                    {
                        mail.Body = "Beste klant. Uw reservering is ontvangen en verwerkt. Laat deze mail zien in de bioscoop als toegangsbewijs. Geniet van de film!" +
                            "\n\nReservering voor film: "+ item.title + 
                            "\n\nAf te rekenen bij kassa: €"+ Variables.totaalPrijs +
                            "\n\nZaal nummer: " + item.theatreNumber;
                    }
                }

                SmtpServer.Send(mail);
            }
        }
    }
}

