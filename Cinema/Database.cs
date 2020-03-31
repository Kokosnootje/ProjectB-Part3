using System;
using System.IO;
using Newtonsoft.Json;

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
    }

    public class DatabaseProgram
    {
        public void DatabaseMain()
        {
            // Indication that database code has begun
            Console.WriteLine("DatabaseMain begins running");

            // Will eventually change to user input, currently manual variable of the database
            Movie[] movies = new Movie[]
            {
                new Movie
                {
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

            /*
            // read file into a string and deserialize JSON to a type
            Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"Database.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"Database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            }*/

            string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            Console.WriteLine(json);

            // Indication that any database code has stopped
            Console.WriteLine("DatabaseMain has stopped running");
        }
    }
}

