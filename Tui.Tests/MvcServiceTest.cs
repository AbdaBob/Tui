using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tui.Mvc.Services;
using Tui.Tests.Handlers;

namespace Tui.Tests
{
    [TestClass]
    public class MvcServiceTest
    {
        private Mock<IHttpClientFactory> _factoryMock;
        private HttpClient _httpClient;

        [TestInitialize]
        public void Init()
        {
            _factoryMock = new Mock<IHttpClientFactory>();
            var handlerMock = new Mock<FakeHttpHandler>() { CallBase = false };
        }

        [DataTestMethod]
        [DataRow("[{}]", 1)]
        [DataRow("[{},{}]", 2)]
        [DataRow("[{},{},{}]", 3)]
        public async Task WhenAskingForAircraftsThenGotTheExpectedCount(string message,int expected)
        {
            _httpClient = GetHttpClient(message);
           
            _factoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(_httpClient);
            var service = new FlightService(_factoryMock.Object);
            var aircrafts = await service.GetAircrafts();
            aircrafts.Count.Should().Be(expected);
            
        }

        [DataTestMethod]
        [DataRow("[{}]", 1)]
        [DataRow("[{},{}]", 2)]
        [DataRow("[{},{},{}]", 3)]
        public async Task WhenAskingForAirportsThenGotTheExpectedCount(string message, int expected)
        {
            _httpClient = GetHttpClient(message);

            _factoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(_httpClient);
            var service = new FlightService(_factoryMock.Object);
            var airports = await service.GetAirports();
            airports.Count.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("[{}]", 1)]
        [DataRow("[{},{}]", 2)]
        [DataRow("[{},{},{}]", 3)]
        public async Task WhenAskingForFlightsThenGotTheExpectedCount(string message, int expected)
        {
            _httpClient = GetHttpClient(message);

            _factoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(_httpClient);
            var service = new FlightService(_factoryMock.Object);
            var flights = await service.GetFlights();
            flights.Count.Should().Be(expected);
            
        }


        [DataTestMethod]
        [DataRow( 1)]
        [DataRow( 2)]
        [DataRow(3)]
        public async Task WhenAskingForFlightIdThenGotTheRightFlight(int id)
        {
            var message = "{\"id\":"+id+",destinationairportid:\"1\"}";
            _httpClient = GetHttpClient(message);
            _factoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(_httpClient);
            var service = new FlightService(_factoryMock.Object);
            var flight = await service.GetFlight(id);

            Assert.AreEqual(id, flight.Id);

        }

        private HttpClient GetHttpClient(string content)
        {
            var message = new HttpResponseMessage()
            {
                Content = new StringContent(content)
            };
            var taskMessage = Task.FromResult(message);
            var handlerMock = new Mock<FakeHttpHandler>() { CallBase = true };
            handlerMock.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(message);

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://www.google.fr")
            };

            return httpClient;
        }
    }
}
