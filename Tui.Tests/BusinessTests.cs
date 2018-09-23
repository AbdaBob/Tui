using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tui.Business;
using Tui.Services.Aircraft;
using Tui.Services.Airport;
using Tui.Services.Flight;

namespace Tui.Tests
{
    [TestClass]
    public class BusinessTests
    {
        private Mock<IFlightService> _flightServiceMock;
        private Mock<IAircraftService> _aircraftServiceMock;
        private Mock<IAirportService> _airportServiceMock;
        private FlightBusiness _business;
        private AirportDto _charlesDeGaulleAirport = new AirportDto { Id = 1, Name = "Charles de Gaulle" };
        private AirportDto _orlyAirport = new AirportDto { Id = 2, Name = "Orly" };
        private AircraftDto _aircraftBoeing = new AircraftDto { Id = 1, Name = "Boeing" };

        [TestInitialize]
        public void Init()
        {
            _flightServiceMock = new Mock<IFlightService>();
            _aircraftServiceMock = new Mock<IAircraftService>();
            _airportServiceMock = new Mock<IAirportService>();

            _airportServiceMock.Setup(a => a.GetAsync(1))
                              .Returns(Task.FromResult(_charlesDeGaulleAirport));
            _airportServiceMock.Setup(a => a.GetAsync(2))
                                .Returns(Task.FromResult(_orlyAirport));
            _aircraftServiceMock.Setup(a => a.GetAsync(1))
                                .Returns(Task.FromResult(_aircraftBoeing));

            _flightServiceMock.Setup(f => f.AddAsync(It.IsAny<FlightDto>())).Returns(Task.FromResult(true));
            _flightServiceMock.Setup(f => f.UpdateAsync(It.IsAny<UpdateFlightDto>())).Returns(Task.FromResult(true));

            _business = new FlightBusiness(_flightServiceMock.Object, _aircraftServiceMock.Object, _airportServiceMock.Object);
        }

        [TestMethod]       
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenAddNullFlyingThenReturnException()
        {
            await _business.AddSync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenUpdateNullFlyingThenReturnException()
        {
            await _business.UpdateAsync(null);
        }


        [TestMethod]
        public async Task WhenUpdateCompleteFlightTheReturnsTrue()
        {
            // Arrange

            var flightDto = new UpdateFlightDto { DepartureAirportId = 1, DestinationAirportId = 2, AircraftId = 1 };
            //Act

            var result = await _business.UpdateAsync(flightDto);
            //Assert
            result.Should().Be(true);
            _flightServiceMock.Verify(f => f.UpdateAsync(flightDto), Times.Once);
        }

        [TestMethod]
        public async Task WhenAddCompleteFlightTheReturnsTrue()
        {
            // Arrange

            var flightDto = new FlightDto { DepartureAirportId = 1, DestinationAirportId = 2, AircraftId = 1 };
            //Act

            var result = await _business.AddSync(flightDto);
            //Assert
            result.Should().Be(true);
            _flightServiceMock.Verify(f => f.AddAsync(flightDto), Times.Once);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenAddCompleteFlightButWrongValuesTheGetArgumentNullException()
        {
            // Arrange
            var flightDto = new FlightDto { DepartureAirportId = 1, DestinationAirportId = 3, AircraftId = 1 };
            
            //Act
            var result = await _business.AddSync(flightDto);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenUpdateCompleteFlightButWrongValuesTheGetArgumentNullException()
        {
            // Arrange
            var flightDto = new UpdateFlightDto { DepartureAirportId = 1, DestinationAirportId = 3, AircraftId = 1 };

            //Act
            var result = await _business.UpdateAsync(flightDto);

        }

        [TestMethod]
        public async Task IfFligthServiceReturnFalseThatBusinessToo()
        {
            _flightServiceMock.Setup(f => f.AddAsync(It.IsAny<FlightDto>())).Returns(Task.FromResult(false));
            _business = new FlightBusiness(_flightServiceMock.Object, _aircraftServiceMock.Object, _airportServiceMock.Object);

            // Arrange

            var flightDto = new FlightDto { DepartureAirportId = 1, DestinationAirportId = 2, AircraftId = 1 };
            //Act

            var result = await _business.AddSync(flightDto);
            //Assert
            result.Should().Be(false);
            _flightServiceMock.Verify(f => f.AddAsync(flightDto), Times.Once);
        }
    }
}
