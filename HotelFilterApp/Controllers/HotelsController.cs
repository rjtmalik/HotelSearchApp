using HotelFilterApp.DAL.Contracts;
using HotelFilterApp.Services.Contracts;
using HotelFilterApp.Services.CustomExceptions;
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
        private readonly IHotelService _hotelService;
        public HotelsController(ILogger<HotelsController> logger,
            IHotelService hotelService)
        {
            _logger = logger;
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("/api/hotels/{hotelId}/arrivalDate/{epochSeconds}/prices")]
        public async Task<ActionResult> GetAsync(int hotelId, long epochSeconds)
        {
            try
            {
                //var filePath = Path.Combine(_appEnvironment.ContentRootPath, @"data/hotelsrates.json");
                //return await ReadFileAsync(filePath);
                return Ok(await _hotelService.GetByAsync(hotelId, DateTimeOffset.FromUnixTimeSeconds(epochSeconds).DateTime));
            }
            catch(HotelNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(404);
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
