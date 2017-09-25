using System;
using System.Reflection;

namespace ServiceBouncer.Extensions
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