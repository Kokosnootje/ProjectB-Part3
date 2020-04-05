using System;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;

namespace Cinema
{
    public class Database
    {
        public class Movie
        {
            public string title { get; set; }
            public string genre { get; set; }
            public string duration { get; set; }
            public string language { get; set; }
            public string theatreNumber { get; set; }
            public string startTime { get; set; }
            public string rating { get; set; }
            public string id { get; set; }
        }

        public class DatabaseProgram
        {
            public void DatabaseMain()
            {
                // Indication that database code has begun
                // Console.WriteLine("DatabaseMain begins running");

                // Will eventually change to user input, currently manual variable of the database
                Movie[] movies = new Movie[]
                {
                new Movie
                {
                    id = "1",
                    title = "Blade",
                    genre = "Action",
                    duration = "1:30:00",
                    language = "English",
                    theatreNumber = "1",
                    startTime = "13:00",
                    rating = "PG13"
                },
                new Movie
                {
                    id = "2",
                    title = "Lord of the Rings",
                    genre = "Adventure",
                    duration = "2:30:00",
                    language = "English",
                    theatreNumber = "2",
                    startTime = "14:00",
                    rating = "PG13"
                },
                new Movie
                {
                    id = "3",
                    title = "Alladdin",
                    genre = "Adventure",
                    duration = "1:45:00",
                    language = "Dutch",
                    theatreNumber = "1",
                    startTime = "14:30",
                    rating = "E"
                },
                new Movie
                {
                    id = "4",
                    title = "IT",
                    genre = "Horror",
                    duration = "2:00:00",
                    language = "English",
                    theatreNumber = "3",
                    startTime = "09:00",
                    rating = "PG13"
                },
                new Movie
                {
                    id = "5",
                    title = "Deadpool",
                    genre = "Action",
                    duration = "1:30:00",
                    language = "English (Dutch Subtitles)",
                    theatreNumber = "1",
                    startTime = "19:00",
                    rating = "R"
                },
                new Movie
                {
                    id = "6",
                    title = "The Lion King",
                    genre = "Cartoon",
                    duration = "1:15:00",
                    language = "Dutch",
                    theatreNumber = "2",
                    startTime = "10:00",
                    rating = "E"
                }
                };

                // Write the "movies" variable to a JSON file
                File.WriteAllText(@"Database.json", JsonConvert.SerializeObject(movies));
                using (StreamWriter file = File.CreateText(@"Database.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, movies);
                }

                // Turn the JSON variable "movies" into a string and read it
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
                //Console.WriteLine(json);

            // Send mail to confirm reservation (Once we have that...)
            DatabaseMail();

            // Indication that any database code has stopped
            // Console.WriteLine("DatabaseMain has stopped running");
        }
        public void DatabaseShow()
        {
            /*
            // read file into a string and deserialize JSON to a type
            Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"Database.json"));

                // Deserialize the json, loop through the movies and select needed variables
                using (StreamReader file = File.OpenText(@"Database.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Movie[] newMovies = JsonConvert.DeserializeObject<Movie[]>(json);
                    foreach (var item in newMovies)
                    {
                        Console.WriteLine("[" + item.id + "] " + "Title: " + item.title + " || " + "Genre: " + item.genre);
                    }
                

                    //Kiezen om een film verder te bekijken
                    Console.WriteLine("\n\nWelke film wilt u bekijken?");
                    int menuNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    
                    //Alles weergeven van gekozen film
                    Console.WriteLine("\nTitle: " + newMovies[menuNumber].title + "\nGenre: " + newMovies[menuNumber].genre + "\nDuration: " + newMovies[menuNumber].duration + "\nLanguage: " + newMovies[menuNumber].language + "\nTheatre Number: " + newMovies[menuNumber].theatreNumber + "\nStart Time: " + newMovies[menuNumber].startTime + "\nRating: " + newMovies[menuNumber].rating);
                    
                    //Menu voor verdere keuzes zoals reserveren
                    Console.WriteLine("\n\nWat wilt u nu doen?\n[1] Film (" + newMovies[menuNumber].title + ") reserveren\n");
                    string filmMenuNumber = Console.ReadLine();
                    if (filmMenuNumber == "1")
                    {
                        Reserveren.Reserveer();
                    }
                    

                
                }


                //Movie newMovie = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"Database.json"));
                //Console.WriteLine("Title is: "+newMovie.title);

                // Indication that any database code has stopped
                // Console.WriteLine("DatabaseMain has stopped running");
            }
            public void DatabaseShow()
            {

                /*
                // read file into a string and deserialize JSON to a type
                Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"Database.json"));

                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(@"Database.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
                }*/
            }
        }

        public void DatabaseMail()
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
            mail.To.Add("kokosnootje77@gmail.com");
            mail.Subject = "Reservering bevestiging";
            mail.Body = "Beste klant. Uw reservering is ontvangen en verwerkt. Laat deze mail zien in de bioscoop als toegangsbewijs. Geniet van de film!";

            SmtpServer.Send(mail);
        }
    }
}

