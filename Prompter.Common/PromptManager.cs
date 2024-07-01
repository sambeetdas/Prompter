using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Common
{
    public class PromptManager
    {
        public async static Task<string> BuildPrefixForSource(string userPrompt)
        {
            StringBuilder sbPrefix = new StringBuilder();
            

            sbPrefix.AppendLine($"Question : '{userPrompt}'");
            sbPrefix.AppendLine("1.Which is the relevant 'http_requests.id' for the above question asked in the below json.\r\n");
            sbPrefix.AppendLine("2.Format the correct 'http_requests.id' in the response within <<>>.\r\n");

            return sbPrefix.ToString();
        }

        public async static Task<string> BuildPrefixForResult(string userPrompt)
        {
            StringBuilder sbPrefix = new StringBuilder();
            

            sbPrefix.AppendLine($"question : '{userPrompt}'");
            sbPrefix.AppendLine("1. Question asked is above within ''.");
            sbPrefix.AppendLine("2. 'Data_Source' hold all the data for the above 'question'.");
            sbPrefix.AppendLine("3. Asked question should be filtered from the 'Data_Source' defined in the 'Key'.");
            sbPrefix.AppendLine("4. Phrase the result to English.");


            return sbPrefix.ToString();
        }
    }
}
