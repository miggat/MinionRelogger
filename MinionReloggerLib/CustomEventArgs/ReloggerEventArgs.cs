using System;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.CustomEventArgs
{
    public class ReloggerEventArgs : EventArgs
    {
        public ReloggerEventArgs(Account account = null, ERelogEventArgsType type = ERelogEventArgsType.OnUnknown)
        {
            Account = account;
            Type = type;
        }

        public Account Account { get; private set; }
        public ERelogEventArgsType Type { get; private set; }
    }
}