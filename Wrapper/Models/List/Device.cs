using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.List
{
    public class Device
    {
        [JsonPropertyName("device")]
        public string Id { get; set; }

        public string Model { get; set; }

        [JsonPropertyName("deviceName")]
        public string Name { get; set; }

        public bool Controllable { get; set; }
        public bool Retrievable { get; set; }

        [JsonPropertyName("supportCmds")]
        public string[] Commands { get; set; }

    }

    public class Properties
    {
        [JsonPropertyName("colorTem")]
        public ColorTemperature ColorTemperature { get; set; }
    }

    public class ColorTemperature
    {
        [JsonPropertyName("range")]
        public ColorTemperatureRange Range { get; set; }
    }

    public class ColorTemperatureRange
    {
        [JsonPropertyName("min")]
        public long Minimum { get; set; }

        [JsonPropertyName("max")]
        public long Maximum { get; set; }

    }
}