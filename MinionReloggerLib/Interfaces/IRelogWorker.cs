using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces
{
    public interface IRelogWorker
    {
        bool Check(Account account);
        IRelogWorker DoWork(Account account);
        void Update(Account account);
        bool PostWork(Account account);
    }
}