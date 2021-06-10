using HotelFilterApp.DAL.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
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

        public async Task<string> GetBy(int hotelId, DateTime arrivalDate)
        {
            var filePath = Path.Combine(_appEnvironment.ContentRootPath, @"data/hotelsrates.json");
            return await ReadFileAsync(filePath);
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
