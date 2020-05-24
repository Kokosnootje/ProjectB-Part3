using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cinema
{
    public class Zalen
    {
        public class Zaal
        {
            public string nummer { get; set; }
            public List<List<string>> stoelen { get; set; }
            public string date { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
        }

        public static void NieuweZaal()
        {

        }

        public static void zalen()
        {
            var zalen = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(@"users.json"));
        }


    }
}
