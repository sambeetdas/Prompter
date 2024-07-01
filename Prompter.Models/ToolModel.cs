using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Models
{
    public class ToolModel
    {
        public List<ToolDetails> http_requests { get; set; }
    }

    public class ToolDetails
    {
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string method { get; set; }
        public List<string> headers { get; set; }
        public Dictionary<string, object> request { get; set; }
        public string responseKeys { get; set; }
    }


}
