﻿using System.Text.Json.Serialization;

namespace PowerIT.Govee.Models.List
{
    public class Response
    {
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Status { get; set; }

        public Data Data { get; set; }
    }
}
