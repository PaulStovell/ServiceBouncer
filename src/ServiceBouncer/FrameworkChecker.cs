using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ServiceBouncer
{
    public static class FrameworkChecker
    {
#if NET45
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
                    if (releaseKey < 378389)
                    {
                        validFramework = false;
                    }
                }
            }

            if (!validFramework)
            {
                MessageBox.Show("ServiceBouncer required .net 4.5 or higher to be installed", "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
#elif NET461
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
                    if (releaseKey < 394254)
                    {
                        validFramework = false;
                    }
                }
            }

            if (!validFramework)
            {
                MessageBox.Show("ServiceBouncer required .net 4.6.1 or higher to be installed", "Framework Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
#endif
    }
}