using System;

public class Database
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
}

