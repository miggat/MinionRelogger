using System.Runtime.InteropServices;

namespace MinionReloggerLib.Imports
{
    public static class Kernel32
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void SetDllDirectory(string lpPathName);
    }
}