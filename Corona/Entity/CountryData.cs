using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Corona.Entity
{
    public class CountryData
    {
        public CountryData()
        {
        }

        [JsonProperty("Turkey")]
        public Data[] Turkey { get; set; }
        [JsonProperty("Italy")]
        public Data[] Italy { get; set; }

    }

    public class Data
    {
        public Data()
        {

        }

        public DateTime Date { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
    }
}
