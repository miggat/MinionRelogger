/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

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