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
                string directoryPath;
                if (fullPath.StartsWith("\"") && fullPath.IndexOf("\"", 1) > 0)
                {
                    var path = fullPath.Substring(1, fullPath.IndexOf("\"", 1) - 1);
                    directoryPath = CreatePath(controller, path);
                    return new FileInfo(directoryPath);
                }

                if (fullPath.Contains(" "))
                {
                    var path = fullPath.Substring(0, fullPath.IndexOf(" "));
                    directoryPath = CreatePath(controller, path);
                    return new FileInfo(directoryPath);
                }

                directoryPath = CreatePath(controller, fullPath);
                return new FileInfo(directoryPath);
            }
        }

        private static string CreatePath(ServiceController controller, string path)
        {
            var machineName = controller.MachineName;

            var volume = path.Substring(0, 1);
            var folder = path.Substring(3);

            if (EnvHelper.IsLocalMachine(machineName))
            {
                return $"{volume}:\\{folder}";
            }

            return $"\\\\{machineName}\\{volume}$\\{folder}";
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

#if NET45
        //NET45 PolyFil as controller doesn't have StartType
        public static string GetStartupType(this ServiceController controller)
        {
            using (var wmiManagementObject = controller.GetNewWmiManagementObject())
            {
                return wmiManagementObject["StartMode"].ToString();
            }
        }
#elif NET461
        public static string GetStartupType(this ServiceController controller)
        {
            return controller.StartType.ToString();
        }
#endif
    }
}