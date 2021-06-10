using HotelFilterApp.DAL.Contracts;
using HotelFilterApp.DAL.Models;
using HotelFilterApp.Services.CustomExceptions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelFilterApp.Services.Tests.Unit
{
    public class Tests
    {

        [Test]
        public void WhenHotelIsAbsentThenThrowException()
        {
            //Arrange
            var dal = new Mock<IHotelDAL>();
            dal.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<HotelRoomRent>());
            var sut = new HotelService(dal.Object);

            //Act && Assert
            Assert.ThrowsAsync<HotelNotFoundException>(() => sut.GetByAsync(1, new System.DateTime()));
        }

        [Test]
        public async Task WhenRateIsUnavailableForDateReturnEmpty()
        {
            //Arrange
            var dal = new Mock<IHotelDAL>();
            var suppliedDay = new System.DateTime();
            dal.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<HotelRoomRent>() {
                new HotelRoomRent() {
                    Hotel = new Hotel() {  HotelID=1},
                    HotelRates = new HotelRate[]
                    {
                        new HotelRate(){ TargetDay = new System.DateTime().AddDays(2)}
                    } } });

            var sut = new HotelService(dal.Object);

            //Act
            var got = await sut.GetByAsync(1, suppliedDay);

            //Assert
            Assert.AreEqual(0, got.HotelRates.Length);
        }

        [Test]
        public async Task WhenRateIsAvailableForDateReturnIt()
        {
            //Arrange
            var dal = new Mock<IHotelDAL>();
            var suppliedDay = new System.DateTime();
            dal.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<HotelRoomRent>() {
                new HotelRoomRent() {
                    Hotel = new Hotel() {  HotelID=1},
                    HotelRates = new HotelRate[]
                    {
                        new HotelRate(){ TargetDay = suppliedDay}
                    } } });

            var sut = new HotelService(dal.Object);

            //Act
            var got = await sut.GetByAsync(1, suppliedDay);

            //Assert
            Assert.AreEqual(1, got.HotelRates.Length);
        }
    }
}