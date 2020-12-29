using System;
using System.Collections.Generic;
using System.Linq;
using VxTel.Domain.Exceptions;
using VxTel.Domain.Models.Data;

namespace VxTel.Domain.Data
{
    public static class AvailablePlans
    {
        private static readonly List<Plan> Plans = new List<Plan>
        {
            new Plan {Name = "FaleMais 30", FreeMinutes = 30f, FeeTax = 0.1f},
            new Plan {Name = "FaleMais 60", FreeMinutes = 60f, FeeTax = 0.1f},
            new Plan {Name = "FaleMais 120", FreeMinutes = 120f, FeeTax = 0.1f}
        };

        public static Plan GetPlan(int index)
        {
            try
            {
                return Plans.ElementAt(index);
            }
            catch (Exception)
            {
                SimulationExceptions.PlanNotFound();
                return new Plan();
            }
        }
    }
}