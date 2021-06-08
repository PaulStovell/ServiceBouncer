using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ServiceBouncer
{
    public static class FrameworkChecker
    {
#if NET45
        private const string ErrorMessage = "ServiceBouncer requires .net 4.5 or higher to be installed";
        private const int MinReleaseKey = 378389;
#elif NET461
        private const string ErrorMessage = "ServiceBouncer requires .net 4.6.1 or higher to be installed";
        private const int MinReleaseKey = 394254;
#elif NET471
        private const string ErrorMessage = "ServiceBouncer requires .net 4.7.1 or higher to be installed";
        private const int MinReleaseKey = 461308;
#elif NET48
        private const string ErrorMessage = "ServiceBouncer requires .net 4.8 or higher to be installed";
        private const int MinReleaseKey = 528040;
#endif

        public static void CheckFrameworkValid()
        {
            var validFramework = true;
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey == null)
                {
                    validFramework = false;
                }
                else
                {
                    var releaseKey = Convert.ToInt32(ndpKey.GetValue("Release"));
                    if (releaseKey < MinReleaseKey)
                    {
                        validFramework = false;
                    }
                }
            }

            if (!validFramework)
            {
                MessageBox.Show(ErrorMessage, "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
