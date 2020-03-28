using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Corona.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Corona.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoronaController : ControllerBase
    {
        public CoronaController()
        {
        }

        [HttpGet]
        public CountryData Get()
        {
            CountryData countryDatas = DownloadAndDeserializeJsonData("https://pomber.github.io/covid19/timeseries.json");
            return countryDatas;
        }

        private CountryData DownloadAndDeserializeJsonData(string url)
        {
            using (var webClient = new WebClient())
            {
                var jsonData = string.Empty;
                try
                {
                    jsonData = webClient.DownloadString(url);
                }
                catch (Exception) { }

                return 
                    JsonConvert.DeserializeObject<CountryData>(jsonData);
            }
        }
    }
}
