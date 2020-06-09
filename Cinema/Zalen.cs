using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cinema
{

    class Zalen
    {
        
        public static void removedStoelen(string datum, string starttijd)
        {
            var reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));

            Console.WriteLine("========SCHERM========");
            var zalen = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<string>>>>(File.ReadAllText(@"zalen.json"));
            List<string> StoelenList = new List<string>();
            foreach (var person in reserveringen)
            {
                foreach (var item in person.Value)
                {
                    if ((item[4] == datum)&(item[3] == starttijd))
                    {
                        int stoelenCount = 5;
                        while (item.Count > stoelenCount)
                        {
                            //Console.WriteLine(item[stoelenCount] + item[stoelenCount + 1]);
                            foreach (var rij in zalen["Zaal1"])
                            {
                                if (rij.Key == item[stoelenCount])
                                {
                                    rij.Value.Remove(item[stoelenCount + 1]);
                                }
                            }
                            stoelenCount += 2;
                        }
                    }
                        
                }
            }
            foreach (var rij in zalen["Zaal1"])
            {
                string str = "";
                str += rij.Key;
                foreach (var stoel in rij.Value)
                {
                    str += " " + stoel;
                }
                Console.WriteLine(str);
            }

        }       
    }
}
