using System;
using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.Control
{
    public class Command
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class Commands
    {
        public static string Turn { get; } = "turn";
        public static string Brightness { get; } = "brightness";
        public static string Color { get; } = "color";
        public static string Temprature { get; } = "colorTem";
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