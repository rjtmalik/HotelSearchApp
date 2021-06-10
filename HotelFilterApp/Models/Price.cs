using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Models
{
    public class Price
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("numericFloat")]
        public float NumericFloat { get; set; }

        [JsonProperty("numericInteger")]
        public int NumericInteger { get; set; }
    }
}
