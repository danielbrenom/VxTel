using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using VxTel.Test.Configuration;
using Xunit;

namespace VxTel.Test.Integration
{
    public class SimulationTest : IClassFixture<ApplicationFactory<Startup>>
    {
        public SimulationTest(ApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateClient();
        }

        private readonly HttpClient _httpClient;

        [Fact]
        public async Task HttpClientIsOk()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldReturnInvalidSimulation()
        {
            const string url = "/simulate/plan/0/origin/15/destination/16/minutes/20";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            var response = await _httpClient.SendAsync(request);
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [Fact]
        public async Task ShouldReturnNotFoundSimulation()
        {
            const string url = "/simulate/plan/5/origin/15/destination/16/minutes/20";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            var response = await _httpClient.SendAsync(request);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ShouldReturnValidSimulation()
        {
            const string url = "/simulate/plan/0/origin/11/destination/16/minutes/20";
            var request = new HttpRequestMessage(new HttpMethod("GET"), url);
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}