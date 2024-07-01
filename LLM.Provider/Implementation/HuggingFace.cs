using LLM.Provider.Contract;
using Prompter.Common;
using Prompter.Models;
using Prompter.Models.HuggingFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LLM.Provider.Implementation
{
    public class HuggingFace : IInference
    {
        public async Task<String> Execute(PromptModel prompt, InferenceConfigModel config)
        {
            string url = ProviderConstant.HuggingFaceBaseUrl + config.LLMName;
            string promptString = await BuildRequest(prompt, config);
            var response = await ApiManager.Post(url, config.AuthKey, promptString);
            return response;
        }
        private async Task<string> BuildRequest(PromptModel prompt, InferenceConfigModel config)
        {
            RequestModel promptModel = new RequestModel();
            promptModel.Inputs = prompt.Prompt;
            //promptModel.Parameters = new RequestParam
            //{
            //    MaxNewToken = config.MaxNewToken,
            //    Temperature = config.Temperature,
            //    TopP = config.TopP
            //};

            return JsonSerializer.Serialize(promptModel);
        }
    }
}
