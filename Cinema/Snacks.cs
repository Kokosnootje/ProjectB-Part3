﻿using System;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Cinema
{
    public class Snacks
    {
        public class Snack
        {
            public int id { get; set; }
            public string category { get; set; }
            public string name { get; set; }
            public double price { get; set; }
        }
        public class SnacksProgram
        {
            public void SnacksShow() //laat alles snacks zien die we hebben
            {
                JsonSerializer serializer = new JsonSerializer();
                Snack[] newSnacks = JsonConvert.DeserializeObject<Snack[]>(File.ReadAllText(@"Snacks.json"));
                foreach (var item in newSnacks)
                {
                    Console.WriteLine("[" + item.id + "] " + item.name + " || " + "prijs: " + item.price);
                }
            }
            public void addSnack()
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Dictionary<string, string>> snackList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(@"Snacks.json"));

                Dictionary<string, string> newSnack = new Dictionary<string, string>();
                newSnack.Add("id", Convert.ToString(snackList.Count + 1));
                Console.Write("Wat is de categorie vand de snack (Drinks or food)?:\n >");
                newSnack.Add("category", Console.ReadLine());
                Console.Write("Wat is de naam van de snack?:\n >");
                newSnack.Add("name", Console.ReadLine());
                Console.Write("Wat is de prijs van de snack?: (Voorbeeld => 12.99)");
                newSnack.Add("price", Console.ReadLine());

                snackList.Add(newSnack);
                using (StreamWriter file = File.CreateText(@"Snacks.json"))
                {
                    JsonSerializer serializerz = new JsonSerializer();
                    serializerz.Serialize(file, snackList);
                    Console.WriteLine("Snack is toegevoegd.");
                }

            }
        }
    }
}