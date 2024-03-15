using LLM.Provider.Contract;
using LLM.Provider.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter
{
    public static class PrompterServiceRegister
    {
        public static void AddPrompterService(this IServiceCollection services)
        {
            services.AddTransient<InferenceModule>();
        }
    }
}
