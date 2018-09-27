using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBouncer
{
    static class EnvHelper
    {
        /// <summary>
        /// Is this the current local machine?
        /// </summary>
        /// <param name="machineHostname"></param>
        /// <returns></returns>
        public static bool IsLocalMachine(string machineHostname)
        {
            machineHostname = machineHostname.Trim();
            var isLocalMachine = machineHostname == "." || Environment.MachineName.Equals(machineHostname, StringComparison.CurrentCultureIgnoreCase);
            return isLocalMachine;
        }
    }
}
