using VxTel.Domain.Models.Requests;
using VxTel.Domain.Models.Response;

namespace VxTel.Domain.Interfaces
{
    public interface ISimulatorService
    {
        public SimulatorResponse SimulatePrice(SimulatorRequest request);
    }
}