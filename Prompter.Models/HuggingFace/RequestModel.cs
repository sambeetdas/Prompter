using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prompter.Models.HuggingFace
{
    public class RequestModel
    {
        [JsonPropertyName("inputs")]
        public string Inputs { get; set; }

        [JsonPropertyName("parameters ")]
        public RequestParam Parameters { get; set; }
    }

    public class RequestParam
    {
        [JsonPropertyName("max_new_tokens ")]
        public double MaxNewToken { get; set; }

        [JsonPropertyName("temperature ")]
        public double Temperature { get; set; }

        [JsonPropertyName("top_p ")]
        public double TopP { get; set; }
    }
}
