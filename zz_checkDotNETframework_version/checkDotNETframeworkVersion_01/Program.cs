using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace checkDotNETframeworkVersion_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string frameworkVersion = GetDotNetFrameworkVersion();
            Console.WriteLine($"Current .NET Framework Version: {frameworkVersion}");

            Console.ReadLine();
        }

        static string GetDotNetFrameworkVersion()
        {
            try
            {
                string version = RuntimeEnvironment.GetSystemVersion();
                return version;
            }
            catch (Exception ex)
            {
                return $"Error getting .NET Framework version: {ex.Message}";
            }
        }
    }
}
