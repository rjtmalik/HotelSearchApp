using HotelFilterApp.Services.Contracts;
using HotelFilterApp.Tests.Contract.Stubs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace HotelFilterApp.Tests.Contract
{
    public class GetHotelRatesForDayTests
        : IClassFixture<WebApplicationFactory<HotelFilterApp.Startup>>
    {
        private readonly WebApplicationFactory<HotelFilterApp.Startup> _factory;

        public GetHotelRatesForDayTests(WebApplicationFactory<HotelFilterApp.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task WhenUnknownHotelThenReturn404()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IHotelService, HotelServiceMock>();
                });
            })
                .CreateClient();

            // Act
            var response = await client.GetAsync("/api/hotels/1/arrivalDate/78798987/prices");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}