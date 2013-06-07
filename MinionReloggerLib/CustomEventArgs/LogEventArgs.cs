using System;
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.CustomEventArgs
{
    public class LogEventArgs
    {
        public readonly DateTime EventTime;

        public readonly string Message;
        public readonly ELogType Type;

        public LogEventArgs(ELogType type, string message)
        {
            EventTime = DateTime.Now;
            Type = type;
            Message = message;
        }
    }
}