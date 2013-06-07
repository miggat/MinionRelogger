using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces
{
    public interface IRelogComponent
    {
        bool Check(Account account);
        IRelogComponent DoWork(Account account);
        bool IsReady(Account account);
        void Update(Account account);
        bool PostWork(Account account);
    }
}