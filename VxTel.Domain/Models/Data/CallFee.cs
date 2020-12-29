namespace VxTel.Domain.Models.Data
{
    public class CallFee
    {
        public int OriginDDD { get; set; }
        public int DestinationDDD { get; set; }
        public float MinuteFee { get; set; }
    }
}