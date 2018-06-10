using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBouncer
{
    public class Options
    {
        [Option('m', "machine", HelpText = "The machine to initially connect to.", Hidden = false, Required = false)]
        public string Machine { get; set; }
    }
}
