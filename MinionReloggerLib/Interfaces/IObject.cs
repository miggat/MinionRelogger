namespace MinionReloggerLib.Interfaces
{
    public interface IObject
    {
        bool Check();
        IObject DoWork();
        bool IsReady();
        void Update();
    }
}