using LLM.Provider.Contract;
using LLM.Provider.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Prompter.Models;
using Prompter.Models.HuggingFace;
using Newtonsoft.Json;
using Prompter.Common;
using System.Text.RegularExpressions;

namespace Prompter
{
    public class InferenceModule
    {
        private readonly IInference _inference;
        private readonly InferenceConfigModel _config;
        public InferenceModule(LLMProvider provider, InferenceConfigModel config)
        {
            if (provider == LLMProvider.HuggingFace)
            {
                _inference = new HuggingFace();
            }
            _config = config;
        }    
       public async Task<string> Processer(InferenceModel inferenceModel)
       {
            try
            {
                if (inferenceModel == null || String.IsNullOrWhiteSpace(inferenceModel.UserPrompt))
                {
                    throw new ArgumentNullException(nameof(inferenceModel.UserPrompt));
                }

                if (_config.ToolModel == null)
                {
                    throw new ArgumentException(nameof(_config.ToolModel));
                }

                PromptModel promptModel = new PromptModel()
                {
                    UserPrompt = inferenceModel.UserPrompt
                };

                var relevantSources = await InferenceSource(promptModel);

                if (relevantSources.Any())
                {
                    var selectedTools = _config.ToolModel.http_requests.FindAll(i => relevantSources.Contains(i.id));
                    if (selectedTools.Any())
                    {
                        var responseFinal = await InferenceResult(promptModel, selectedTools);

                        return responseFinal;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return "No result found for the question.";
        }

        private async Task<List<string>> InferenceSource(PromptModel promptModel)
        {
            List<string> relevantSources = new List<string>();
            promptModel = await BuildPromptSource(promptModel);
            var response = await _inference.Execute(promptModel, _config);

            if (string.IsNullOrWhiteSpace(response))
            {
                throw new Exception("Source API is null");
            }

            string pattern = @"<<(.*?)>>";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(response);

            foreach (Match match in matches)
            {
                if (!String.IsNullOrEmpty(match.Groups[1].Value))
                {
                    relevantSources.Add(match.Groups[1].Value.Trim().Replace("\\\"", ""));
                }

            }

            return relevantSources;
        }

        private async Task<string> InferenceResult(PromptModel promptModel, List<ToolDetails> selectedTools)
        {
            foreach (var tool in selectedTools)
            {
                var responseSource = await ApiManager.Get(tool.url, null);
                promptModel = await BuildPromptResult(promptModel, tool, responseSource);                
            }

            var response = await _inference.Execute(promptModel, _config);

            return response;
        }

        private async Task<PromptModel> BuildPromptSource(PromptModel promptModel)
        {
            var prefix = await PromptManager.BuildPrefixForSource(promptModel.UserPrompt);
            promptModel.Prompt = prefix + JsonConvert.SerializeObject(_config.ToolModel);
            return promptModel;
        }

        private async Task<PromptModel> BuildPromptResult(PromptModel promptModel, ToolDetails tool, string response)
        {
            var prefix = await PromptManager.BuildPrefixForResult(promptModel.UserPrompt);
            promptModel.Prompt += $"Data_Source : {response}" + $"Key : {tool.responseKeys}";
            return promptModel;
        }
    }
}
