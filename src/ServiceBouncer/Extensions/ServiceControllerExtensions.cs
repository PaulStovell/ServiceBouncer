using System.IO;
using System.Management;
using System.ServiceProcess;

namespace ServiceBouncer.Extensions
{
    public static class ServiceControllerExtensions
    {
        private static ManagementObject GetNewWmiManagementObject(this ServiceController controller)
        {
            return new ManagementObject(new ManagementPath($"\\\\{controller.MachineName}\\root\\cimv2:Win32_Service.Name='{controller.ServiceName}'"));
        }

        public static FileInfo GetExecutablePath(this ServiceController controller)
        {
            using (var wmiManagementObject = controller.GetNewWmiManagementObject())
            {
                var fullPath = wmiManagementObject["PathName"].ToString();
                string UncPath;
                if (fullPath.StartsWith("\"") && fullPath.IndexOf("\"", 1) > 0)
                {
                    var path = fullPath.Substring(1, fullPath.IndexOf("\"", 1) - 1);
                    UncPath = $"\\\\{controller.MachineName}\\{path.Substring(0, 1)}$\\{path.Substring(3)}";
                    return new FileInfo(UncPath);
                }

                if (fullPath.Contains(" "))
                {
                    var path = fullPath.Substring(0, fullPath.IndexOf(" "));
                    UncPath = $"\\\\{controller.MachineName}\\{path.Substring(0, 1)}$\\{path.Substring(3)}";
                    return new FileInfo(UncPath);
                }

                UncPath = $"\\\\{controller.MachineName}\\{fullPath.Substring(0, 1)}$\\{fullPath.Substring(3)}";
                return new FileInfo(UncPath);
            }
        }

        public static void SetStartupType(this ServiceController controller, ServiceStartMode newType)
        {
            using (var wmiManagementObject = controller.GetNewWmiManagementObject())
            {
                var parameters = new object[1];
                parameters[0] = newType.ToString();
                wmiManagementObject.InvokeMethod("ChangeStartMode", parameters);
            }
        }

        public static string GetStartupType(this ServiceController controller)
        {
#if NET45
            using (var wmiManagementObject = controller.GetNewWmiManagementObject())
            {
                return wmiManagementObject["StartMode"].ToString();
            }
#elif NET461
            return controller.StartType.ToString();
#endif
        }
    }
}