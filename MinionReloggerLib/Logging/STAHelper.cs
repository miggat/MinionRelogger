using System;
using System.Threading;
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Logging
{
    public abstract class STAHelper
    {
        private readonly ManualResetEvent _complete = new ManualResetEvent(false);
        internal bool DontRetryWorkOnFailed { get; set; }

        internal void Go()
        {
            var thread = new Thread(DoWork)
                {
                    IsBackground = true,
                };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void DoWork()
        {
            try
            {
                _complete.Reset();
                Work();
            }
            catch (Exception ex)
            {
                if (DontRetryWorkOnFailed)
                    throw;
                else
                {
                    try
                    {
                        Thread.Sleep(1000);
                        Work();
                    }
                    catch
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    }
                }
            }
            finally
            {
                _complete.Set();
            }
        }

        protected abstract void Work();
    }
}