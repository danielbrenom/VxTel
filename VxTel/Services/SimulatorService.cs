using System;
using VxTel.Data;
using VxTel.Exceptions;
using VxTel.Interfaces;
using VxTel.Models.Requests;
using VxTel.Models.Response;

namespace VxTel.Services
{
    public class SimulatorService : ISimulatorService
    {
        public SimulatorResponse SimulatePrice(SimulatorRequest request)
        {
            var selectedPlan = AvailablePlans.GetPlan(request.DesiredPlan);
            var selectedFee = AvailableFees.GetFee(request.OriginDDD, request.DestinationDDD);
            if (selectedFee is null) SimulationExceptions.DddNoMatch();
            var minutesToPay = Math.Max(0, request.DesiredMinutes - selectedPlan.FreeMinutes);
            var priceWithout = selectedFee.MinuteFee * request.DesiredMinutes;
            var priceWith = minutesToPay * (selectedFee.MinuteFee + selectedFee.MinuteFee * selectedPlan.FeeTax);

            return new SimulatorResponse
            {
                PriceWith = priceWith,
                PriceWithout = priceWithout,
                OriginDDD = request.OriginDDD,
                DestinationDDD = request.DestinationDDD,
                SelectedPlan = selectedPlan.Name,
                DesiredMinutes = request.DesiredMinutes
            };
        }
    }
}