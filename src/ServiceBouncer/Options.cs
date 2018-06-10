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
        private string machine;

        [Option('m', "machine", HelpText = "The machine to initially connect to.", Hidden = false, Required = false)]
        public string Machine
        {
            get
            {
                if (string.IsNullOrWhiteSpace(machine))
                {
                    return Environment.MachineName;
                }
                else
                {
                    return machine;
                }
            }
            set
            {
                machine = value;
            }
        }
    }
}
