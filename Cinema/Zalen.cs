using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cinema
{

    class Zalen
    {
        public static void zaal1()
        {
            var zalen = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(File.ReadAllText(@"zalen.json"));
        }
    }
}
