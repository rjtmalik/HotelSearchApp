using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.DAL.Models
{
    public class Hotel
    {
        [JsonProperty("classification")]
        public int Classification { get; set; }

        [JsonProperty("hotelID")]
        public int HotelID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("reviewscore")]
        public float ReviewScore { get; set; }
    }
}
