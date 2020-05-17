﻿using System;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema
{
    public class Movies
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

        public class MovieProgram
        {
            public void MovieShow() //laat alles films zien die we hebben
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie[] newMovies = JsonConvert.DeserializeObject<Movie[]>(File.ReadAllText(@"Movies.json"));
                foreach (var item in newMovies)
                {
                    Console.WriteLine("[" + item.id + "] " + "Title: " + item.title + " || " + "Genre: " + item.genre);
                }
            }

            public void filterMovie()
            {
                string filter = "";
                Console.WriteLine("Zoeken op:\n[1] Genre\n[2] Titel\n[3] Taal");
                Console.Write("> ");
                string menuChoice = Console.ReadLine();
                if (menuChoice == "1")
                {
                    Console.WriteLine("Welk genre wilt u zien?:\n[1] Action\n[2] Adventure\n[3] Cartoon\n[4] Horror");
                    Console.Write("> ");
                    filter = Console.ReadLine();
                    if (filter == "1")
                    {
                        filter = "Action";
                    }
                    else if (filter == "2")
                    {
                        filter = "Adventure";
                    }
                    else if (filter == "3")
                    {
                        filter = "Cartoon";
                    }
                    else if (filter == "4")
                    {
                        filter = "Horror";
                    }
                }
                else if (menuChoice == "2")
                {
                    Console.WriteLine("Type de naam of een gedeelte daar van hier in");
                    Console.Write("> ");
                    filter = Console.ReadLine();
                }
                else if (menuChoice == "3")
                {
                    Console.WriteLine("In welke taal wilt u een film zien?:\n[1] Engels\n[2] Nederlands");
                    Console.Write("> ");
                    filter = Console.ReadLine();
                    if (filter == "1")
                    {
                        filter = "English";
                    }
                    else if (filter == "2")
                    {
                        filter = "Dutch";
                    }
                }
                JsonSerializer serializer = new JsonSerializer();
                Movie[] newMovies = JsonConvert.DeserializeObject<Movie[]>(File.ReadAllText(@"Movies.json"));
                foreach (var item in newMovies)
                {
                    if (filter == item.genre || item.title.Contains(filter) || item.language.Contains(filter))
                        Console.WriteLine("[" + item.id + "] " + "Title: " + item.title + " || " + "Genre: " + item.genre);
                }

            }

            public void pickMovie()
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie[] newMovies = JsonConvert.DeserializeObject<Movie[]>(File.ReadAllText(@"Movies.json"));                
                Console.WriteLine("Welke film wilt u reserveren? voer het nummer van de film in");
                try
                {
                    int menuNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (menuNumber == newMovies.Length)
                    {
                        
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
                        Console.WriteLine("\nWat wilt u nu doen?\n[1] Film (" + newMovies[menuNumber].title + ") reserveren\n[2] Ga terug");
                        string filmMenuNumber = Console.ReadLine();
                        if (filmMenuNumber == "1")
                        {
                            Reserveren.Reserveer();
                        }
                        else if (filmMenuNumber == "2")
                        {
                            Console.WriteLine("\n");
                            
                        }
                        else
                        {
                            Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.\n");
                        }
                    }
                }
                catch(Exception e)
                {
                    // HAAL DIT WEG ZODRA APP KLAAR IS!
                    Console.WriteLine(e);

                    Console.WriteLine("\nOngeldige invoer. Probeer opnieuw.\n");
                }
            }
        
            public void addMovie()
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Dictionary<string, string>> movieList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(@"Movies.json"));

                Dictionary<string, string> newMovie = new Dictionary<string, string>();
                newMovie.Add("id", Convert.ToString(movieList.Count + 1));
                Console.Write("Wat is de titel van de film?:\n >");
                newMovie.Add("title", Console.ReadLine());
                Console.Write("Wat is het genre?:\n >");
                newMovie.Add("genre", Console.ReadLine());
                Console.Write("hoe lang duurt de film?: (gebruik dit format => 00:00:00)\n >");
                newMovie.Add("duration", Console.ReadLine());
                Console.Write("In welke taal is de film?:\n >");
                newMovie.Add("language", Console.ReadLine());
                Console.Write("Wat is het zaal nummer van deze film?:\n >");
                newMovie.Add("theatreNumber", Console.ReadLine());
                Console.Write(" hoe laat start de film?: (gebruik dit format => 2020-05-07T13:00:00)\n >");
                newMovie.Add("startTime", Console.ReadLine());
                Console.Write("Welke rating heeft deze film?: (Voorbeeld => PG13)\n >");
                newMovie.Add("rating", Console.ReadLine());
                Console.Write("hoe veel kost deze film?: (Voorbeeld => 12.99)\n >");
                newMovie.Add("price", Console.ReadLine());

                movieList.Add(newMovie);
                using (StreamWriter file = File.CreateText(@"Movies.json"))
                {   
                    JsonSerializer serializerz = new JsonSerializer();
                    serializerz.Serialize(file, movieList);
                    Console.WriteLine("Film is toegevoegd.");
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
                Movies.Movie[] newMovies = JsonConvert.DeserializeObject<Movies.Movie[]>(File.ReadAllText(@"Movies.json"));
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

