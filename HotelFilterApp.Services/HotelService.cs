using HotelFilterApp.DAL.Contracts;
using HotelFilterApp.DAL.Models;
using HotelFilterApp.Services.Contracts;
using HotelFilterApp.Services.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFilterApp.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelDAL _hotelDAL;
        
        public HotelService(IHotelDAL hotelDAL)
        {
            _hotelDAL = hotelDAL;
        }

        public async Task<HotelRoomRent> GetByAsync(int hotelId, DateTime arrivalDate)
        {
            var hotelRoomRent = (await _hotelDAL.GetAllAsync()).FirstOrDefault(h => h.Hotel.HotelID == hotelId);
            if (hotelRoomRent == null)
                throw new HotelNotFoundException($"No data available for hotel {hotelId}");
            
            var dateSpecificRates = hotelRoomRent.HotelRates
                .Where(d => d.TargetDay.ToUniversalTime().Date == arrivalDate.Date).ToArray();
            
            return new HotelRoomRent() { Hotel = hotelRoomRent.Hotel, HotelRates = dateSpecificRates };
        }
    }
}
