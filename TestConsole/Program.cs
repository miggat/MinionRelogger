using System;
using System.Windows.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.Initialize(new ListBox());
            ComponentManager.Singleton.LoadComponents();
            ThreadManager.Singleton.Initialize();
            Config.Singleton.GeneralSettings.SetGW2Path(@"I:\Guild Wars 2\GW2.exe");
            Config.Singleton.GeneralSettings.SetMinimizeWindows(false);
            var test = new Account();
            test.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
            test.SetEndTime(DateTime.Now.AddMinutes(1337));
            test.SetLoginName("robert.vd.boorn@gmail.com");
            test.SetManuallyScheduled(false);
            test.SetNoSound(true);
            test.SetPassword("minion-bot");
            test.SetSchedulingEnabled(false);
            test.SetStartTime(DateTime.Now.AddSeconds(30));
            test.SetSchedulingEnabled(true);
            var test2 = new BreakObject();
            test.SetBreak(test2);
            test.BreakObject.Interval = 1;
            test.BreakObject.BreakDuration = 1;
            test.BreakObject.IntervalDelay = 1;
            test.BreakObject.BreakDurationDelay = 1;
            test.BreakObject.BreakEnabled = true;
            Config.Singleton.AddAccount(test);
            test.BreakObject.Update();


            var test3 = new Account();
            test3.SetSchedulingEnabled(true);
            test3.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
            test3.SetEndTime(DateTime.Now.AddMinutes(1337));
            test3.SetLoginName("mmopewpew@gmail.com");
            test3.SetManuallyScheduled(false);
            test3.SetNoSound(true);
            test3.SetPassword("mmominion");
            test3.SetSchedulingEnabled(true);
            test3.SetStartTime(DateTime.Now.AddSeconds(120));
            var test4 = new BreakObject();
            test3.SetBreak(test4);
            test3.BreakObject.Interval = 1;
            test3.BreakObject.BreakDuration = 1;
            test3.BreakObject.IntervalDelay = 1;
            test3.BreakObject.BreakDurationDelay = 1;
            test3.BreakObject.BreakEnabled = true;
            Config.Singleton.AddAccount(test3);
            test3.BreakObject.Update();

            Console.ReadLine();
        }
    }
}