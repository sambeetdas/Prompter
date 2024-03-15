using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.Test
{
    public class TestSetupFixture : IDisposable
    {
        public TestSetupFixture()
        {
            var serviceProvider = new ServiceCollection();
            serviceProvider.BuildServiceProvider();
        }
        public void Dispose()
        {

        }
    }
}
