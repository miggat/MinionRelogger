using System;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces.RelogComponents
{
    public class BreakComponent : IRelogComponent
    {
        public bool Check(Account account)
        {
            throw new NotImplementedException();
        }

        public IRelogComponent DoWork(Account account)
        {
            throw new NotImplementedException();
        }

        public bool IsReady(Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }

        public bool PostWork(Account account)
        {
            throw new NotImplementedException();
        }
    }
}