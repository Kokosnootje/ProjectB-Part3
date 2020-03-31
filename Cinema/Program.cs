using System;
using System.IO;
using Newtonsoft.Json;

namespace Cinema
{
    public class Employee
    {
        public string username { get; set; }
        public string password { get; set; }
    }
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
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie
            {
                title = "Blade",
                genre = "Action",
                duration = "1:30:00",
                language = "English",
                theatreNumber = "1",
                startTime = "13:00",
                rating = "PG13"
            };
            //string json = JsonConvert.SerializeObject(movie, Formatting.Indented);

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"C:\Users\judac\source\repos\Cinema\Cinema\Database.json", JsonConvert.SerializeObject(movie));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Users\judac\source\repos\Cinema\Cinema\Database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movie);
            }

            /*
            // read file into a string and deserialize JSON to a type
            Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"C:\Users\judac\source\repos\Cinema\Cinema\Database.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\judac\source\repos\Cinema\Cinema\Database.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            }
            */
            //Console.WriteLine(json);
        }
    }
}
