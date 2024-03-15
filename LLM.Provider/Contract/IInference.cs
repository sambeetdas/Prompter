﻿using Prompter.Models.HuggingFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Provider.Contract
{
    public interface IInference
    {
        Task<String> Execute(string modelId, string authToken, PromptModel promptModel);
    }
}
