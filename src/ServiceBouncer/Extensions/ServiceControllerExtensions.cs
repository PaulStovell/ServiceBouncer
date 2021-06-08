using System;
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

                const string quote = "\"";

                if (fullPath.StartsWith(quote) && fullPath.IndexOf(quote, 1) > 0)
                {
                    //e.g. "C:\Program Files (x86)\Google\Update\GoogleUpdate.exe" /svc
                    fullPath = fullPath.Substring(1, fullPath.IndexOf(quote, 1) - 1);
                }

                var file = Path.GetFileName(fullPath);
                //split filename on space for arguments - note: space in filename isn't working yet.
                if (file.Contains(" "))
                {
                    var dir = Path.GetDirectoryName(fullPath);

                    //e.g. fullpath C:\Windows\system32\svchost.exe -k AxInstSVGroup
                    file = file.Substring(0, file.IndexOf(" "));

                    var path = Path.Combine(dir, file);

                    directoryPath = CreatePath(controller, path);
                    return new FileInfo(directoryPath);
                }

                directoryPath = CreatePath(controller, fullPath);
                return new FileInfo(directoryPath);
            }
        }

        private static string CreatePath(ServiceController controller, string path)
        {
            var isUnc = path.StartsWith(@"\\");
            if (isUnc)
            {
                //no need to reformat
                return path;
            }

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
    }
}
