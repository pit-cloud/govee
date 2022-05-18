using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.Control
{
    public class Request
    {
        [JsonPropertyName("device")]
        public string Id { get; set; }

        public string Model { get; set; }

        [JsonPropertyName("cmd")]
        public Command Command { get; set; }
    }
}
