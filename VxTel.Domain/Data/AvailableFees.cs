using System.Collections.Generic;
using System.Linq;
using VxTel.Domain.Models.Data;

namespace VxTel.Domain.Data
{
    public static class AvailableFees
    {
        private static readonly List<CallFee> Fees = new List<CallFee>
        {
            new CallFee {OriginDDD = 11, DestinationDDD = 16, MinuteFee = 1.9f},
            new CallFee {OriginDDD = 16, DestinationDDD = 11, MinuteFee = 2.9f},
            new CallFee {OriginDDD = 11, DestinationDDD = 17, MinuteFee = 1.7f},
            new CallFee {OriginDDD = 17, DestinationDDD = 11, MinuteFee = 2.7f},
            new CallFee {OriginDDD = 11, DestinationDDD = 18, MinuteFee = 0.9f},
            new CallFee {OriginDDD = 18, DestinationDDD = 11, MinuteFee = 1.9f}
        };

        public static CallFee GetFee(int origin, int dest)
        {
            return Fees.FirstOrDefault(fee => fee.OriginDDD == origin && fee.DestinationDDD == dest);
        }
    }
}