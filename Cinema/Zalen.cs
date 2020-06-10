using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Cinema
{

    class Zalen
    {
        
        public static void removedStoelen(string datum, string starttijd, string Zaal)
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
                            foreach (var rij in zalen[Zaal])
                            {
                                if (rij.Key == item[stoelenCount][0].ToString())
                                {
                                    if (item[stoelenCount].Length > 2)
                                    {
                                        rij.Value[Convert.ToInt32((item[stoelenCount][1].ToString() + item[stoelenCount][2].ToString()))-1] = "*";
                                        
                                    }
                                    else
                                    {
                                        rij.Value[Convert.ToInt32((item[stoelenCount][1].ToString()))-1] = "*";
                                        
                                    }
                                    
                                }
                            }
                            stoelenCount += 1;
                        }
                    }
                        
                }
            }
            foreach (var rij in zalen[Zaal])
            {

                
                string str = "";
                str += rij.Key;
                foreach (var stoel in rij.Value)
                {
                    if (rij.Value.Contains(stoel))
                        str += " " + stoel;
                    else
                        str += "  ";
                }

                Console.WriteLine(str);
            }

        }
        public static void checkAvailability(string datum, string starttijd, string Zaal, string stoel)
        {
            var reserveringen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"Reserveringen.json"));

            var zalen = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<string>>>>(File.ReadAllText(@"zalen.json"));
            Variables.stoelAvailable = true;
            foreach (var person in reserveringen)
            {
                
                foreach (var item in person.Value)
                {
                    if ((item[4] == datum) & (item[3] == starttijd) & (item[1] == Zaal))
                    {
                        
                        if (item.Contains(stoel))
                        {
                            Variables.stoelAvailable = false;
                        }
                        else
                        {
                                
                        }
                    }
                }
                
            }
            
        }
    }
}
