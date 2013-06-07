using System;
using MinionReloggerLib.Helpers.Encryption;
using ProtoBuf;

namespace MinionReloggerLib.Interfaces.Objects
{
    public class Account : IObject
    {
        [ProtoMember(1)] private string _loginName;
        [ProtoMember(2)] private string _password;

        [ProtoMember(3)]
        public bool NoSound { get; private set; }

        [ProtoMember(4)]
        public string BotPath { get; private set; }

        [ProtoMember(5)]
        public BreakObject BreakObject { get; private set; }

        public bool ManuallyScheduled { get; private set; }
        public bool ShouldBeRunning { get; private set; }
        public uint PID { get; private set; }
        public int Index { get; private set; }

        public DateTime LastCrash { get; private set; }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime LastStart { get; private set; }
        public DateTime LastStop { get; private set; }

        public string LoginName
        {
            get { return DataProtector.DecryptData(_loginName); }
            private set { _loginName = DataProtector.EncryptData(value); }
        }

        public string Password
        {
            get { return DataProtector.DecryptData(_password); }
            private set { _password = DataProtector.EncryptData(value); }
        }

        public bool Check()
        {
            throw new NotImplementedException();
        }

        public IObject DoWork()
        {
            throw new NotImplementedException();
        }

        public bool IsReady()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void SetNoSound(bool newNoSound)
        {
            NoSound = newNoSound;
        }

        public void SetLoginName(string newLoginName)
        {
            LoginName = newLoginName;
        }

        public void SetPassword(string newPassword)
        {
            Password = newPassword;
        }

        public void SetIndex(int newIndex)
        {
            Index = newIndex;
        }

        public void SetLastCrash(DateTime newLastCrash)
        {
            LastCrash = newLastCrash;
        }

        public void SetPID(uint newPID)
        {
            PID = newPID;
        }

        public void SetStartTime(DateTime newStartTime)
        {
            StartTime = newStartTime;
        }

        public void SetEndTime(DateTime newEndTime)
        {
            EndTime = newEndTime;
        }

        public void SetLastStartTime(DateTime newStartTime)
        {
            LastStart = newStartTime;
        }

        public void SetLastStopTime(DateTime newStopTime)
        {
            LastStop = newStopTime;
        }

        public void SetShouldBeRunning(bool newShouldBeRunning)
        {
            ShouldBeRunning = newShouldBeRunning;
        }

        public void SetManuallyScheduled(bool newManuallyScheduled)
        {
            ManuallyScheduled = newManuallyScheduled;
        }

        public void SetBotPath(string newPath)
        {
            BotPath = newPath;
        }

        public void SetBreak(BreakObject newBreak)
        {
            BreakObject = newBreak;
        }
    }
}