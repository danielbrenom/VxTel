using VxTel.Exceptions;
using VxTel.Interfaces;
using VxTel.Models.Requests;
using VxTel.Models.Response;
using VxTel.Services;
using Xunit;

namespace VxTelTest.Unit
{
    public class SimulatorServiceTest
    {
        public SimulatorServiceTest()
        {
            _simulatorService = new SimulatorService();
        }

        private readonly ISimulatorService _simulatorService;

        [Fact]
        public void ServiceConstructionOk()
        {
            Assert.IsAssignableFrom<ISimulatorService>(_simulatorService);
        }

        [Fact]
        public void SimulationShouldReturnValidResponse()
        {
            var desiredRequest = new SimulatorRequest
            {
                DesiredPlan = 0,
                DesiredMinutes = 20,
                OriginDDD = 11,
                DestinationDDD = 16
            };
            var expectedResponse = new SimulatorResponse
            {
                SelectedPlan = "FaleMais 30",
                OriginDDD = 11,
                DestinationDDD = 16,
                DesiredMinutes = 20,
                PriceWith = 0f,
                PriceWithout = 38f
            };
            var response = _simulatorService.SimulatePrice(desiredRequest);
            Assert.Equal(expectedResponse.PriceWith, response.PriceWith);
            Assert.Equal(expectedResponse.PriceWithout, response.PriceWithout);
        }

        [Fact]
        public void SimulationShouldThrowOnInvalidDDD()
        {
            var desiredRequest = new SimulatorRequest
            {
                DesiredPlan = 5,
                DesiredMinutes = 20,
                OriginDDD = 11,
                DestinationDDD = 20
            };
            Assert.Throws<HttpResponseException>(() => { _simulatorService.SimulatePrice(desiredRequest); });
        }

        [Fact]
        public void SimulationShouldThrowOnInvalidPlan()
        {
            var desiredRequest = new SimulatorRequest
            {
                DesiredPlan = 5,
                DesiredMinutes = 20,
                OriginDDD = 11,
                DestinationDDD = 16
            };
            Assert.Throws<HttpResponseException>(() => { _simulatorService.SimulatePrice(desiredRequest); });
        }
    }
}