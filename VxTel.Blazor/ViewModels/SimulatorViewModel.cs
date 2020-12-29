using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VxTel.Domain.Interfaces;
using VxTel.Domain.Models.Requests;
using VxTel.Domain.Models.Response;

namespace VxTel.Blazor.ViewModels
{
    public class SimulatorViewModel
    {
        public SimulatorViewModel(ISimulatorService service)
        {
            Service = service;
        }

        private ISimulatorService Service { get; }
        public ObservableCollection<SimulatorResponse> SimulatorResponses { get; set; } = new ObservableCollection<SimulatorResponse>();
        public SimulatorRequest SimulationData { get; set; } = new() {DesiredMinutes = 11};

        public async Task SimulateFee()
        {
            try
            {
                await Task.Run(() =>
                {
                    var response = Service.SimulatePrice(SimulationData);
                    SimulatorResponses.Add(response);
                });
            }
            catch (System.Exception e)
            {
                
            }
        }
    }
}