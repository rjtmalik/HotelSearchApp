using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Models
{
    public class RateTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shape")]
        public string Shape { get; set; }
    }
}
