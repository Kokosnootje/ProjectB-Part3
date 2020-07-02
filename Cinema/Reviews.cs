using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cinema
{
    public class Reviews
    {
        public class Review
        {
            public int id { get; set; }
            public string user { get; set; }
            public string movie { get; set; }
            public int rating { get; set; }
        }
        public class ReviewProgram
        {
            public void ShowReviews()
            {
                JsonSerializer serializer = new JsonSerializer();
                Review[] newReview = JsonConvert.DeserializeObject<Review[]>(File.ReadAllText(@"review.json"));
                Console.WriteLine("Reviews\n");
                foreach (var item in newReview)
                {
                        Console.WriteLine("Review:");
                        Console.WriteLine("Door: " + item.user + "\nFilm: " + item.movie + "\nRating: " + item.rating + "\n");
                }
            }
            public void addReview()
            {
                Console.WriteLine("Test");
            }
        }
    }
}
