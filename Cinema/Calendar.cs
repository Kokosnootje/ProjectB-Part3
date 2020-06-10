using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Cinema
{
    public class Calendar
    {
        static void saveCalendar(Dictionary<string, Dictionary<string, List<List<string>>>> calendar, bool refresh)
        //slaat veranderingen op van de agenda in de database en update het aantal beschikbare datums
        //deze functie hoeft niet en kan als het goed is niet aangeroepen worden buiten dit programma, dit is een functie die de calendar zelf aanroept wanneer het nodig is
        // bool refresh(True): deze is er voor om het json bestandje aan te vullen met extra dagen aan het begin van het programma
        {
            if (refresh)
            {
                calendar = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(File.ReadAllText(@"calendar.json"));
            }

            DateTime today = DateTime.Today;

            for (int n = 0; n <= 60; n++)
            {
                var tempDict = new Dictionary<string, List<List<string>>>();
                var tempList = new List<List<string>>();

                if (calendar.ContainsKey(today.AddDays(n).ToString("d")) == false)
                {
                    string date = today.AddDays(n).ToString("d");
                    calendar.Add(date, tempDict);

                    for (int zaalNR = 1; zaalNR <= 3; zaalNR++)
                    {
                        calendar[date].Add("Zaal" + zaalNR, tempList);
                    }
                }
            }

            using (StreamWriter file = File.CreateText(@"calendar.json"))
            {
                //var json = JsonConvert.SerializeObject(calendar, Formatting.Indented);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, calendar);
            }
        }

        public static void showfilms(string datum)
        {
            //laat alle films in alle zalen zien van een specefieke datum
            //showfilms("25/05/2020"); <- Voorbeeld
            var calendar = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(File.ReadAllText(@"calendar.json"));
            Console.WriteLine($"Alle films die gepland staan op {datum}:\n");
            var n = 1;
            foreach (var zaal in calendar[datum]) //NOTE invalide datum crashd het programma! :(
            {
                foreach (var films in zaal.Value)
                {
                    var str = zaal.Key;
                    foreach (var filmdata in films)
                    {
                        str += " " + filmdata;
                    }
                    str += " ";
                    Console.WriteLine("["+n+"] " + str);
                    n += 1;
                }
            }

        }


        public static void planFilm(string datum, string zaal, string filmTitel, string start, string eind)
        {
            //Deze functie zet een film op de calendar, kan nog niet checken op overlap! Hieronder staat een voorbeeld
            //planFilm("26/05/2020", "Zaal1", "boy doez big money", "09:32", "23:59");
            var calendar = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(File.ReadAllText(@"calendar.json"));
            var list = new List<string> { filmTitel, start, eind };
            calendar[datum][zaal].Add(list);
            saveCalendar(calendar, false);
            Console.WriteLine("Film is toegevoegd!");
        }


        public static void runCalendar()
        //Als het programma geopend word kan deze functie gebruikt worden om de agenda te updaten en aan te vullen met nieuwe data
        {      
            var calendar = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(File.ReadAllText(@"calendar.json"));
            saveCalendar(calendar, true);          
        }
    }
}

