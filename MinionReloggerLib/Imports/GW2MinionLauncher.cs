using System;
using System.Runtime.InteropServices;
using System.Text;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Imports
{
    public static class GW2MinionLauncher
    {
        [DllImport("GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern uint LaunchAccount([MarshalAs(UnmanagedType.LPWStr)] string exePath,
                                                [MarshalAs(UnmanagedType.LPWStr)] string account,
                                                [MarshalAs(UnmanagedType.LPWStr)] string password, bool noSound);

        [DllImport("GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool KillInstance(uint pid);

        [DllImport("GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool AccountName(UInt32 pid, StringBuilder name, int bufSize);

        public static string GetAccountName(uint pid)
        {
            try
            {
                var buf = new StringBuilder(255);
                AccountName(pid, buf, buf.Capacity);
                return buf.ToString();
            }
            catch (AccessViolationException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
            }
            return "<null>";
        }

        [DllImport("GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Attach(uint pid);
    }
}