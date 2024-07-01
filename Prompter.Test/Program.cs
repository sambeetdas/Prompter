using LLM.Provider.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Prompter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Ask question:");
            string input = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(input))
            {
                var services = new ServiceCollection();
                services.AddPrompterService();

                var config = new InferenceConfigModel
                {
                    LLMName = "mistralai/Mistral-7B-Instruct-v0.3",
                    AuthKey = "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",
                    MaxNewToken = 100,
                    Temperature = 0.7,
                    TopP = 0.9,
                    ToolModel = new ToolModel
                    {
                        http_requests = new List<ToolDetails>
                    {
                        new ToolDetails
                        {
                            id = "get_all_phones",
                            description = "This api is used to get the list of phones",
                            url = "https://api.restful-api.dev/objects",
                            method = "GET",
                            headers = new List<string> {},
                            request = new Dictionary<string, object>(),
                            responseKeys = "{name},{price}"
                        },
                        new ToolDetails
                        {
                            id = "get_breeds_of_dogs",
                            description = "This api is used to get the list of breeds of dogs",
                            url = "https://dogapi.dog/api/v2/breeds",
                            method = "GET",
                            headers = new List<string> {},
                            request = new Dictionary<string, object>(),
                            responseKeys = "{name},{description}"
                        }
                    }
                    }
                };

                

                InferenceModule inferenceModule = new InferenceModule(LLMProvider.HuggingFace, config);

                var infModel = new InferenceModel
                {
                    UserPrompt = input,
                };

                var response = await inferenceModule.Processer(infModel);

                Console.WriteLine(response);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No question found. Re-run the application again.");
            }   
        }
    }
}
