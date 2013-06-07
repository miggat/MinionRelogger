using System.Collections.Generic;
using System.Linq;
using System.Net;
using MetroFramework;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Configuration.Settings
{
    [ProtoContract]
    public class GeneralSettings
    {
        public List<IPAddress> AllowedIPAddresses = new List<IPAddress>();
        [ProtoMember(7)] public List<string> AllowedIPAddressesAsString = new List<string>();

        public GeneralSettings()
        {
            GW2Path = "";
            PollingDelay = 3000;
            LaunchDelay = 20000;
            RestartDelay = 300;
        }

        [ProtoMember(1)]
        public string GW2Path { get; private set; }

        [ProtoMember(2)]
        public int PollingDelay { get; private set; }

        [ProtoMember(3)]
        public int StyleSetting { get; private set; }

        [ProtoMember(4)]
        public int ThemeSetting { get; private set; }

        [ProtoMember(5)]
        public bool MinimizeWindows { get; private set; }

        [ProtoMember(6)]
        public int LaunchDelay { get; private set; }

        [ProtoMember(8)]
        public bool CheckForIP { get; private set; }

        [ProtoMember(9)]
        public int RestartDelay { get; private set; }

        public void SetGW2Path(string newPath)
        {
            Logger.LoggingObject.Log(ELogType.Info, "GW2 Path has been changed to: [{0}].", newPath);
            GW2Path = newPath;
        }

        public void SetPollingDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Polling delay has been changed to: [{0}].", newDelay);
            PollingDelay = newDelay;
        }

        public void SetLaunchDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Launch delay has been changed to: [{0}].", newDelay);
            LaunchDelay = newDelay;
        }

        public void SetRestartDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Restart delay has been changed to: [{0}].", newDelay);
            RestartDelay = newDelay;
        }

        public void SetStyleSetting(int newStyle)
        {
            StyleSetting = newStyle;
            Logger.LoggingObject.Log(ELogType.Info, "Switched to color: {0}.", ((MetroColorStyle) newStyle).ToString());
        }

        public void SetThemeSetting(int newTheme)
        {
            ThemeSetting = newTheme;
            Logger.LoggingObject.Log(ELogType.Info, "Switched to theme: {0}.", ((MetroThemeStyle) newTheme).ToString());
        }

        public void SetMinimizeWindows(bool newMinimize)
        {
            MinimizeWindows = newMinimize;
            Logger.LoggingObject.Log(ELogType.Info, "Minimize windows has been changed to: {0}.", newMinimize);
        }

        public void AddIP(IPAddress newAddress)
        {
            AllowedIPAddresses.Add(newAddress);
            Logger.LoggingObject.Log(ELogType.Info, "Added IP address {0} to the list of allowed addresses.",
                                     newAddress.ToString());
        }

        public void DeleteIP(IPAddress toDeleteAddress)
        {
            IPAddress wanted = AllowedIPAddresses.FirstOrDefault(ip => ip.Equals(toDeleteAddress));
            if (wanted == null)
                return;
            AllowedIPAddresses.Remove(wanted);
            Logger.LoggingObject.Log(ELogType.Info, "Deleted IP address {0} from the list of allowed addresses.",
                                     toDeleteAddress.ToString());
        }

        public void SetCheckForIP(bool newValue)
        {
            CheckForIP = newValue;
            Logger.LoggingObject.Log(ELogType.Info, "Check for IP has been changed to: {0}.", newValue);
        }
    }
}