using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace ComponentTest
{
    public class TestComponent : IRelogComponent
    {
        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            Logger.LoggingObject.Log("[TestComponent] DoWork");
            return this;
        }

        public string GetName()
        {
            Logger.LoggingObject.Log("[TestComponent] GetName");
            return "TestComponent (external DLL test)";
        }

        public void OnEnable()
        {
            Logger.LoggingObject.Log("[TestComponent] OnEnable");
        }

        public void OnDisable()
        {
            Logger.LoggingObject.Log("[TestComponent] OnDisable");
        }

        public void OnLoad()
        {
            Logger.LoggingObject.Log("[TestComponent] OnLoad");
        }

        public void OnUnload()
        {
            Logger.LoggingObject.Log("[TestComponent] OnUnload");
        }
        
    }
}