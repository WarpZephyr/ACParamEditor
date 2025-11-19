using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AcParamEditor
{
    internal static class AppInfo
    {
        public static readonly string Platform;
        public static readonly string Version;
#if DEBUG
        public const bool IsDebug = true;
#else
        public const bool IsDebug = false;
#endif
        public const string AppName = "AcSaveConverter";
        public static readonly string AppFilePath;
        public static readonly string AppDirectory;

        static AppInfo()
        {
            Platform = GetPlatform();
            Version = GetVersion();
            AppFilePath = Environment.ProcessPath ?? "Unknown";
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        private static string GetVersion()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var version = executingAssembly.GetName().Version;
            if (version != null)
            {
                return version.ToString();
            }
            else
            {
                return "0.0.0.0";
            }
        }

        private static string GetPlatform()
        {
            string platform;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                platform = "Linux";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                platform = "FreeBSD";
            }
            else
            {
                return Environment.OSVersion.ToString();
            }

            var osVersion = Environment.OSVersion;
            string servicePack = osVersion.ServicePack;
            return string.IsNullOrEmpty(servicePack) ?
               $"{platform} {osVersion.Version}" :
               $"{platform} {osVersion.Version.ToString(3)} {servicePack}";
        }
    }
}
