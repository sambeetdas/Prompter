using LLM.Provider.Contract;
using LLM.Provider.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Prompter.Models;
using Prompter.Models.HuggingFace;

namespace Prompter
{
    public class InferenceModule
    {
        private readonly IInference _inference;
        public InferenceModule(IInference inference)
        {
            _inference = inference;
        }    
       public async Task<string> Processer(string model, string authToken, string question, double MaxNewToken, double Temperature, double TopP)
        {
            string prompt = string.Empty;
            PromptModel promptModel = new PromptModel();
            promptModel.Inputs = question;
            promptModel.Parameters = new PromptParam
            {
                MaxNewToken = MaxNewToken,
                Temperature = Temperature,
                TopP = TopP
            };
            return await _inference.Execute(model, authToken, promptModel);
        }
    }
}
