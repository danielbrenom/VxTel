using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using VxTel;
using VxTel.Interfaces;
using VxTel.Services;

namespace VxTelTest.Configuration
{
    public class ApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => { services.AddSingleton<ISimulatorService, SimulatorService>(); });
        }
    }
}