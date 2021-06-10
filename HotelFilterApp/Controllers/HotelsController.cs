using HotelFilterApp.DAL.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HotelFilterApp.Controllers
{
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ILogger<HotelsController> _logger;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IHotelDAL _hotelDAL;
        public HotelsController(ILogger<HotelsController> logger,
            IHostingEnvironment appEnvironment,
            IHotelDAL hotelDAL)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
            _hotelDAL = hotelDAL;
        }

        [HttpGet]
        [Route("/api/hotels")]
        public async Task<string> Get()
        {
            try
            {
                var filePath = Path.Combine(_appEnvironment.ContentRootPath, @"data/hotelsrates.json");
                //return await ReadFileAsync(filePath);
                return await _hotelDAL.GetBy(1, new DateTime());
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
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
