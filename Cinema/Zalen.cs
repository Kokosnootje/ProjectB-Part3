using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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

                int cnt = 1;
                string str = "";
                str += rij.Key;
                while (cnt <= 10)
                {

                    foreach (var stoel in rij.Value)
                    {
                        if (Int16.Parse(stoel) == cnt)
                        {
                            str += " " + stoel;
                            cnt++;
                        }
                        else
                        {
                            while (cnt < Int16.Parse(stoel))
                            {
                                str += " *";
                                cnt++;
                            }

                        }
                    }
                    if (cnt <= 10)
                    {
                        cnt++;
                        str += " *";
                    }
                }

                /*foreach (var stoel in rij.Value)
                {
                    if (rij.Value.Contains(cnt.ToString()))
                        str += " " + stoel;
                    else
                        str += "  ";
                }*/


                Console.WriteLine(str);
            }

        }       
    }
}
