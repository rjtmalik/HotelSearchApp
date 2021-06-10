using HotelFilterApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFilterApp.DAL.Contracts
{
    public interface IHotelDAL
    {
        Task<IEnumerable<HotelRoomRent>> GetAllAsync();
    }
}
