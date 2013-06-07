using System.Collections.Generic;
using System.Linq;
using System.Net;
using MetroFramework;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
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
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsGW2PathChanged), newPath);
            GW2Path = newPath;
        }

        public void SetPollingDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsPollingDelayChanged), newDelay);
            PollingDelay = newDelay;
        }

        public void SetLaunchDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsLaunchDelayChanged), newDelay);
            LaunchDelay = newDelay;
        }

        public void SetRestartDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsRestartDelayChanged), newDelay);
            RestartDelay = newDelay;
        }

        public void SetStyleSetting(int newStyle)
        {
            StyleSetting = newStyle;
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsColorChanged), ((MetroColorStyle)newStyle).ToString());
        }

        public void SetThemeSetting(int newTheme)
        {
            ThemeSetting = newTheme;
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsThemeChanged), ((MetroThemeStyle)newTheme).ToString());
        }

        public void SetMinimizeWindows(bool newMinimize)
        {
            MinimizeWindows = newMinimize;
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsMinimizeWindowsChanged), newMinimize);
        }

        public void AddIP(IPAddress newAddress)
        {
            AllowedIPAddresses.Add(newAddress);
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsAddedIP), newAddress.ToString());
        }

        public void DeleteIP(IPAddress toDeleteAddress)
        {
            IPAddress wanted = AllowedIPAddresses.FirstOrDefault(ip => ip.Equals(toDeleteAddress));
            if (wanted == null)
                return;
            AllowedIPAddresses.Remove(wanted);
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsDeletedIP),
                                     toDeleteAddress.ToString());
        }

        public void SetCheckForIP(bool newValue)
        {
            CheckForIP = newValue;
            Logger.LoggingObject.Log(ELogType.Info, LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsCheckForIPChanged), newValue);
        }
    }
}