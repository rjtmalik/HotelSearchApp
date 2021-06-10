using HotelFilterApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Services.Contracts
{
    public interface IHotelService
    {
        Task<HotelRoomRent> GetByAsync(int hotelId, DateTime arrivalDate);
    }
}
