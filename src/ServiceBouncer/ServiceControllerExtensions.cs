using System.Management;
using System.ServiceProcess;

namespace ServiceBouncer
{
    public static class ServiceControllerExtensions
    {
        //    public static string StartUpType(this ServiceController controller)
        //    {
        //        using (var wmiManagementObject = new ManagementObject(new ManagementPath(string.Format("Win32_Service.Name='{0}'", controller.ServiceName))))
        //        {
        //            return wmiManagementObject["StartMode"].ToString();
        //        }
        //    }

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