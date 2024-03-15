using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prompter.Models.HuggingFace
{
    public class PromptModel
    {
        [JsonPropertyName("inputs")]
        public string Inputs { get; set; }

        [JsonPropertyName("parameters ")]
        public PromptParam Parameters { get; set; }
    }

    public class PromptParam
    {
        [JsonPropertyName("max_new_tokens ")]
        public double MaxNewToken { get; set; }

        [JsonPropertyName("temperature ")]
        public double Temperature { get; set; }

        [JsonPropertyName("top_p ")]
        public double TopP { get; set; }
    }
}
