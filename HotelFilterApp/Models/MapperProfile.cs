using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFilterApp.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DAL.Models.HotelRoomRent, HotelRoomRent>();
            CreateMap<DAL.Models.Hotel, Hotel>();
            CreateMap<DAL.Models.HotelRate, HotelRate>();
            CreateMap<DAL.Models.Price, Price>();
            CreateMap<DAL.Models.RateTag, RateTag>();
        }
    }
}
