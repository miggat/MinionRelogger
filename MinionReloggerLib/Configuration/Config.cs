using System.Collections.Generic;
using System.Linq;
using MinionReloggerLib.Configuration.Settings;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Configuration
{
    [ProtoContract]
    public class Config
    {
        private static Config _instance;

        [ProtoMember(2)] public List<Account> AccountSettings;
        [ProtoMember(1)] public GeneralSettings GeneralSettings;

        protected Config()
        {
            AccountSettings = new List<Account>();
            GeneralSettings = new GeneralSettings();
        }

        public static Config Singleton
        {
            get { return _instance ?? (_instance = new Config()); }
            set { _instance = value; }
        }

        public bool AccountExists(Account account)
        {
            return AccountSettings.Any(s => account.LoginName == s.LoginName);
        }

        public void DeleteAccount(Account account)
        {
            Account wanted = AccountSettings.FirstOrDefault(
                a => a.LoginName == account.LoginName);
            if (wanted != null)
            {
                AccountSettings.Remove(wanted);
            }
        }

        public void AddAccount(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Debug, LanguageManager.Singleton.GetTranslation(ETranslations.ConfigNewAccount));
            account.SetIndex(AccountSettings.Count);
            AccountSettings.Add(account);
        }

        public void EraseAccountList()
        {
            AccountSettings.Clear();
        }
    }
}