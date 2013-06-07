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

using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.MyIP;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces.RelogComponents
{
    public class IPCheckComponent : IRelogComponent
    {
        private bool _isEnabled;

        public bool Check(Account account)
        {
            return Config.Singleton.GeneralSettings.CheckForIP && account.Running;
        }

        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            if (Check(account))
            {
                result = EComponentResult.Continue;
                if (IsReady(account))
                {
                    result = EComponentResult.Kill;
                }
            }
            else
            {
                result = EComponentResult.Ignore;
            }
            return this;
        }

        public bool IsReady(Account account)
        {
            return !GetMyIP.ListContainsMyIPAddress(Config.Singleton.GeneralSettings.AllowedIPAddresses);
        }

        public void Update(Account account)
        {
        }

        public bool PostWork(Account account)
        {
            return true;
        }

        public bool IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

        public string GetName()
        {
            return "IPCheckComponent";
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void OnLoad()
        {
        }

        public void OnUnload()
        {
        }
    }
}