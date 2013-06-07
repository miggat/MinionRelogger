using System;
using System.Diagnostics;
using System.IO;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;
using MinionReloggerLib.Helpers.Language;

namespace MinionReloggerLib.Interfaces.RelogWorkers
{
    public class StartWorker : IRelogWorker
    {
        private bool _attached;
        private Process[] _gw2Processes;
        private uint _newPID;

        public bool Check(Account account)
        {
            return CheckIfProcessAlreadyExists(_gw2Processes, account, _attached, ref _newPID);
        }

        public IRelogWorker DoWork(Account account)
        {
            _attached = false;
            _newPID = uint.MaxValue;
            _gw2Processes = Process.GetProcessesByName("gw2");
            Logger.LoggingObject.Log(ELogType.Debug, LanguageManager.Singleton.GetTranslation(ETranslations.StartWorkerScanningForExisting));
            _attached = Check(account);
            _newPID = CreateNewProcess(_attached, account, ref _newPID);
            Update(account);
            PostWork(account);
            return this;
        }

        public void Update(Account account)
        {
            account.SetPID(_newPID);
        }

        public bool PostWork(Account account)
        {
            return _newPID < uint.MaxValue;
        }

        private uint CreateNewProcess(bool attached, Account account, ref uint newPID)
        {
            if (!attached)
            {
                try
                {
                    try
                    {
                        if (Directory.Exists(account.BotPath) &&
                            File.Exists(account.BotPath + "\\GW2MinionLauncherDLL.dll"))
                            Kernel32.SetDllDirectory(account.BotPath);
                        Logger.LoggingObject.Log(ELogType.Verbose, LanguageManager.Singleton.GetTranslation(ETranslations.StartWorkerLaunchingInstance),
                                                 account.LoginName, account.BotPath + "\\GW2MinionLauncherDLL.dll");
                        newPID = GW2MinionLauncher.LaunchAccount(Config.Singleton.GeneralSettings.GW2Path,
                                                                 account.LoginName, account.Password, account.NoSound);
                    }
                    catch (AccessViolationException ex)
                    {
                        Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                    }
                    account.SetLastStartTime(DateTime.Now);
                    account.SetShouldBeRunning(true);
                }
                catch (DllNotFoundException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
                catch (BadImageFormatException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
            }
            return newPID;
        }

        private bool CheckIfProcessAlreadyExists(Process[] gw2Processes, Account account, bool attached, ref uint newPID)
        {
            foreach (Process p in gw2Processes)
            {
                if (GW2MinionLauncher.GetAccountName((uint) p.Id) == account.LoginName)
                {
                    Logger.LoggingObject.Log(ELogType.Verbose, LanguageManager.Singleton.GetTranslation(ETranslations.StartWorkerFoundWantedProcess),
                                             account.LoginName);
                    try
                    {
                        Logger.LoggingObject.Log(ELogType.Verbose, LanguageManager.Singleton.GetTranslation(ETranslations.StartWorkerAttachingTo),
                                                 account.LoginName, account.BotPath + "\\GW2MinionLauncherDLL.dll");
                        if (Directory.Exists(account.BotPath) &&
                            File.Exists(account + "\\GW2MinionLauncherDLL.dll"))
                            Kernel32.SetDllDirectory(account.BotPath);
                        attached = GW2MinionLauncher.Attach((uint) p.Id);
                    }
                    catch (AccessViolationException ex)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    }
                    newPID = (uint) p.Id;

                    account.SetLastStartTime(DateTime.Now);
                    account.SetShouldBeRunning(true);
                }
            }
            return attached;
        }
    }
}