using System;

namespace ServiceBouncer
{
    public static class EnvHelper
    {
        /// <summary>
        /// Is this the current local machine?
        /// </summary>
        /// <param name="machineHostname"></param>
        /// <returns></returns>
        public static bool IsLocalMachine(string machineHostname)
        {
            machineHostname = machineHostname.Trim();
            return machineHostname == "." || Environment.MachineName.Equals(machineHostname, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
