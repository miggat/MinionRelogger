using System;
using System.Diagnostics;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
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
                Process.Kill();
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