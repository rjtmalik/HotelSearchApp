using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.DAL.Models
{
    public class HotelRoomRent
    {
        [JsonProperty("hotel")]
        public Hotel Hotel { get; set; }

        [JsonProperty("hotelRates")]
        public HotelRate[] HotelRates { get; set; }
    }
}
