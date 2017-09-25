using System;
using System.Reflection;

namespace ServiceBouncer
{
    public static class AssemblyExtensions
    {
        public static T GetCustomAttributeOrNull<T>(this Assembly assembly) where T : Attribute
        {
            try
            {
                return assembly.GetCustomAttribute<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}