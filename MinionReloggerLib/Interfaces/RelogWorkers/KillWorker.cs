using System;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Interfaces.RelogWorkers
{
    public class KillWorker : IRelogWorker
    {
        private bool _done;

        public bool Check(Account account)
        {
            return account.PID != uint.MaxValue;
        }

        public IRelogWorker DoWork(Account account)
        {
            if (Check(account))
            {
                try
                {
                    _done = GW2MinionLauncher.KillInstance(account.PID);
                }
                catch (DllNotFoundException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
                catch (BadImageFormatException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
                catch (AccessViolationException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                }
            }
            return this;
        }

        public void Update(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Info, "Stopping process with PID {0}.", account.PID);
            account.SetLastStopTime(DateTime.Now);
        }

        public bool PostWork(Account account)
        {
            return _done;
        }
    }
}