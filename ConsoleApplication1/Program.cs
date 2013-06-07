using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinionReloggerLib.Logging;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Logger.LoggingObject = new Logger.ListBoxLog(new ListBox());
        
        
            MinionReloggerLib.Core.ThreadManager.Singleton.Initialize();
            MinionReloggerLib.Core.ComponentManager.Singleton.LoadComponents();
            while (true)
            {
                Thread.Sleep(2000);
            }
        }
    }
}
