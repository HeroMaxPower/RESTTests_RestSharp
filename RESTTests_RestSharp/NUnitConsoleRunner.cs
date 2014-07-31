using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTTests_RestSharp
{
    class NUnitConsoleRunner
    {
        [STAThread]
        static void Main(string[] args)
        {
            NUnit.ConsoleRunner.Runner.Main(args);
        }
    }
}
