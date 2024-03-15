using LLM.Provider.Contract;
using Prompter.Common;
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
        public async Task<String> Execute(string modelId, string authToken, PromptModel promptModel)
        {
            string url = ProviderConstant.HuggingFaceBaseUrl + modelId;
            string promptString = JsonSerializer.Serialize(promptModel);
            var response = await ApiManager.Post(url, authToken, promptString);
            return response;
        }
    }
}
