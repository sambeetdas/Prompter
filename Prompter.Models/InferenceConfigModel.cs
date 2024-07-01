using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Models
{
    public class InferenceConfigModel
    {
        public InferenceConfigModel() 
        {
            ToolModel = new ToolModel();
        }
        public string LLMName { get; set; }
        public string AuthKey { get; set; }
        public double MaxNewToken { get; set; }
        public double Temperature { get; set; }
        public double TopP { get; set; }
        public ToolModel ToolModel { get; set; }
    }
}
