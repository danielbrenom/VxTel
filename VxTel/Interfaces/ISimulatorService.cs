using VxTel.Models.Requests;
using VxTel.Models.Response;

namespace VxTel.Interfaces
{
    public interface ISimulatorService
    {
        public SimulatorResponse SimulatePrice(SimulatorRequest request);
    }
}