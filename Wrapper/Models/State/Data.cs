using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.State
{
    public class Data
    {
        [JsonPropertyName("device")]
        public string Id { get; set; }

        public string Model { get; set; }
        public List<Properties> Properties { get; set; }
    }
}