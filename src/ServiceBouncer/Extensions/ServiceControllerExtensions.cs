using System.IO;
using System.Management;
using System.ServiceProcess;

namespace ServiceBouncer.Extensions
{
    public static class ServiceControllerExtensions
    {
        public static FileInfo GetExecutablePath(this ServiceController controller)
        {
            using (var wmiManagementObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", controller.ServiceName))))
            {
                var fullPath = wmiManagementObject["PathName"].ToString();
                if (fullPath.StartsWith("\"") && fullPath.IndexOf("\"", 1) > 0)
                {
                    var path = fullPath.Substring(1, fullPath.IndexOf("\"", 1) - 1);
                    return new FileInfo(path);
                }

                if (fullPath.Contains(" "))
                {
                    var path = fullPath.Substring(0, fullPath.IndexOf(" "));
                    return new FileInfo(path);
                }

                return new FileInfo(fullPath);
            }
        }

        public static void SetStartupType(this ServiceController controller, ServiceStartMode newType)
        {
            using (var wmiManagementObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", controller.ServiceName))))
            {
                var parameters = new object[1];
                parameters[0] = newType.ToString();
                wmiManagementObject.InvokeMethod("ChangeStartMode", parameters);
            }
        }
    }
}