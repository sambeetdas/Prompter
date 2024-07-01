using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Models
{
    public class PromptModel : InferenceModel
    {
        public string Prompt { get; set; }
    }
}
