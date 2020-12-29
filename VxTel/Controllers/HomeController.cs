using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VxTel.Domain.Exceptions;
using VxTel.Domain.Interfaces;
using VxTel.Domain.Models;
using VxTel.Domain.Models.Requests;

namespace VxTel.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ISimulatorService _simulatorService;

        public HomeController(ISimulatorService simulatorService)
        {
            _simulatorService = simulatorService;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/simulate/plan/{plan}/origin/{origin}/destination/{dest}/minutes/{min}")]
        public JsonResult Simulate(int plan, int origin, int dest, int min)
        {
            try
            {
                var simulationResult = _simulatorService.SimulatePrice(
                    new SimulatorRequest
                        {DesiredPlan = plan, OriginDDD = origin, DestinationDDD = dest, DesiredMinutes = min});
                return Json(simulationResult);
            }
            catch (HttpResponseException exception)
            {
                return new JsonResult(exception.Value)
                {
                    StatusCode = exception.Status
                };
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}