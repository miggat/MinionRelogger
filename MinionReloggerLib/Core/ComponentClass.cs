using MinionReloggerLib.Interfaces;

namespace MinionReloggerLib.Core
{
    internal class ComponentClass
    {
        internal IRelogComponent Component { get; set; }
        internal bool IsEnabled { get; set; }
    }
}