using Newtonsoft.Json;

namespace VxTel.Models.Requests
{
    public class SimulatorRequest
    {
        public int DesiredPlan { get; set; }

        [JsonProperty("origin_ddd")] public int OriginDDD { get; set; }

        [JsonProperty("destination_ddd")] public int DestinationDDD { get; set; }

        [JsonProperty("desired_minutes")] public int DesiredMinutes { get; set; }
    }
}