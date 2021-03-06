﻿/*****************************************************************************
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

using System;
using System.Diagnostics;
using System.Threading;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Interfaces.Objects
{
    public class WatchObject : IObject
    {
        public WatchObject(Account account, DateTime time, Process process)
        {
            Account = account;
            Time = time;
            Process = process;
        }

        public Account Account { get; private set; }
        public DateTime Time { get; private set; }
        public Process Process { get; private set; }

        public bool Check()
        {
            return IsReady() && !Process.Responding && !Process.HasExited &&
                   (DateTime.Now - Process.StartTime).TotalSeconds > 90;
        }

        public IObject DoWork()
        {
            if (!Process.HasExited)
            {
                try
                {
                    bool result = GW2MinionLauncher.KillInstance((uint) Process.Id);
                    Thread.Sleep(3000);
                    if (!result || (Process != null && !Process.HasExited))
                        Process.Kill();
                }
                catch (Exception ex)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                }
            }
            Update();
            return this;
        }

        public bool IsReady()
        {
            return (DateTime.Now - Time).TotalSeconds > 90;
        }

        public void Update()
        {
            Account.SetLastStopTime(DateTime.Now);
            Logger.LoggingObject.Log(ELogType.Critical,
                                     LanguageManager.Singleton.GetTranslation(ETranslations.WatchObjectNotRespondingFor),
                                     Account.LoginName);
        }
    }
}