using HotelFilterApp.DAL.Models;
using HotelFilterApp.Services.Contracts;
using HotelFilterApp.Services.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.Tests.Contract.Stubs
{
    internal class HotelServiceMock : IHotelService
    {
        public Task<HotelRoomRent> GetByAsync(int hotelId, DateTime arrivalDate)
        {
            throw new HotelNotFoundException($"Rates not available for {hotelId}");
        }
    }
}
