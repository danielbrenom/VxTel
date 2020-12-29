using Newtonsoft.Json;

namespace VxTel.Models.Response
{
    public class SimulatorResponse
    {
        [JsonProperty("origin_ddd")] public int OriginDDD { get; set; }

        [JsonProperty("destination_ddd")] public int DestinationDDD { get; set; }

        [JsonProperty("desired_minutes")] public int DesiredMinutes { get; set; }

        [JsonProperty("selected_plan")] public string SelectedPlan { get; set; }

        [JsonProperty("price_with")] public float PriceWith { get; set; }

        [JsonProperty("price_without")] public float PriceWithout { get; set; }
    }
}