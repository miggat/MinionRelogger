using MinionReloggerLib.Interfaces.Objects;

namespace MinionReloggerLib.Interfaces
{
    public interface IRelogComponentExtension
    {
        bool Check(Account account);
        bool IsReady(Account account);
        void Update(Account account);
        void PostWork(Account account);
    }
}