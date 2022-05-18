using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.Control
{
    public class Response
    {
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Status { get; set; }
    }
}
