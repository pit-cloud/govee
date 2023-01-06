using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.State
{
    public class Properties
    {
        public object Online { get; set; }
        public string PowerState { get; set; }
        public int? Brightness { get; set; }
        public Color Color { get; set; }
    }

    public class Color
    {
        [JsonPropertyName("r")]
        public int Red { get; set; }

        [JsonPropertyName("g")]
        public int Green { get; set; }

        [JsonPropertyName("b")]
        public int Blue { get; set; }
    }
}