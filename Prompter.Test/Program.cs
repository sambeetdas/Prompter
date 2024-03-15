using LLM.Provider.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddPrompterService();


            InferenceModule inferenceModule = new InferenceModule(new HuggingFace());
            var response = await inferenceModule.Processer("HuggingFaceH4/zephyr-7b-beta", "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", "who is messi?",100, 0.7, 0.9);

            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
