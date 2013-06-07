using System;
using System.Linq;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces.RelogWorkers;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Interfaces.Objects
{
    [ProtoContract]
    public class BreakObject : IObject
    {
        public BreakObject()
        {
            TimeSinceLastBreak = DateTime.Now;
            TimeActualStartBreak = DateTime.Now;
            TimeActualStopBreak = DateTime.Now;

            TimeSpanInterval = new TimeSpan(0, 0, 0);
            TimeSpanToAddToLastBreak = new TimeSpan(0, 0, 0);
            TimeSpanToPause = new TimeSpan(0, 0, 0);
            TimeSpanToWaitLonger = new TimeSpan(0, 0, 0);

            BreakEnabled = false;
        }

        public DateTime TimeSinceLastBreak { get; set; }

        public DateTime TimeActualStartBreak { get; set; }

        public DateTime TimeActualStopBreak { get; set; }

        public TimeSpan TimeSpanInterval { get; set; }

        public TimeSpan TimeSpanToAddToLastBreak { get; set; }

        public TimeSpan TimeSpanToPause { get; set; }

        public TimeSpan TimeSpanToWaitLonger { get; set; }

        [ProtoMember(1)]
        public bool BreakEnabled { get; set; }

        [ProtoMember(2)]
        public string LoginName { get; set; }

        [ProtoMember(3)]
        public int Interval { get; set; }

        [ProtoMember(4)]
        public int IntervalDelay { get; set; }

        [ProtoMember(5)]
        public int BreakDuration { get; set; }

        [ProtoMember(6)]
        public int BreakDurationDelay { get; set; }

        public bool Check()
        {
            return BreakEnabled && (DateTime.Now - TimeActualStartBreak).TotalSeconds <= 0;
        }

        public IObject DoWork()
        {
            if (IsReady())
            {
                Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == LoginName);
                if (wanted != null)
                {
                    new KillWorker().DoWork(wanted);
                }
            }
            else if (Check())
            {
                Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == LoginName);
                if (wanted != null)
                {
                    if (new KillWorker().DoWork(wanted).PostWork(wanted))
                    {
                        Update();
                    }
                }
            }
            return this;
        }

        public bool IsReady()
        {
            return BreakEnabled && (TimeActualStopBreak - DateTime.Now).TotalSeconds <= 0;
        }

        public void Update()
        {
            var r = new Random();
            Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == LoginName);
            TimeSinceLastBreak = DateTime.Now;
            TimeSpanInterval = new TimeSpan(0, Interval, 0);
            TimeSpanToAddToLastBreak = new TimeSpan(0, r.Next(0, IntervalDelay), 0);
            TimeSpanToPause = new TimeSpan(0, BreakDuration, 0);
            TimeSpanToWaitLonger = new TimeSpan(0, r.Next(0, BreakDurationDelay), 0);
            TimeActualStartBreak = TimeSinceLastBreak +
                                   TimeSpanInterval +
                                   TimeSpanToAddToLastBreak;
            TimeActualStopBreak = TimeActualStartBreak +
                                  TimeSpanToPause +
                                  TimeSpanToWaitLonger;
            if (wanted != null)
            {
                Logger.LoggingObject.Log(ELogType.Info,
                                         "Break has expired for {0}, starting new cycle!",
                                         wanted.LoginName);
            }
            Logger.LoggingObject.Log(ELogType.Info, "New Start Break: {0}, New End Break: {1}.",
                                     TimeActualStartBreak,
                                     TimeActualStopBreak);
        }
    }
}