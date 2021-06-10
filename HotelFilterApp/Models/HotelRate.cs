﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Models
{
    public class HotelRate
    {
        [JsonProperty("adults")]
        public int Adults { get; set; }

        [JsonProperty("los")]
        public int Los { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("rateDescription")]
        public string RateDescription { get; set; }

        [JsonProperty("rateID")]
        public string RateID { get; set; }

        [JsonProperty("rateName")]
        public string RateName { get; set; }

        [JsonProperty("rateTags")]
        public RateTag[] RateTags { get; set; }

        [JsonProperty("targetDay")]
        public DateTime TargetDay { get; set; }
    }
}
