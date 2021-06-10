using HotelFilterApp.DAL.Contracts;
using HotelFilterApp.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HotelFilterApp.DAL
{
    public class ReadHotelFromFileDAL : IHotelDAL
    {
        private readonly IHostingEnvironment _appEnvironment;
        
        public ReadHotelFromFileDAL(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<IEnumerable<HotelRoomRent>> GetAllAsync()
        {
            var filePath = Path.Combine(_appEnvironment.ContentRootPath, @"data/hotelsrates.json");
            var strRoomRents = await ReadFileAsync(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<HotelRoomRent>>(strRoomRents);
        }

        private async Task<string> ReadFileAsync(string filePath)
        {
            byte[] result;

            using (FileStream SourceStream = System.IO.File.Open(filePath, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }

            return System.Text.Encoding.ASCII.GetString(result);
        }
    }
}
