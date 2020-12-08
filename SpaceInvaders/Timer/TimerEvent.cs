using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class TimerEvent : DLink
    {
        public Name name;
        public float deltaTimeToTrigger;
        public float triggerTime;
        private Command pCommand;

        public enum Name
        {
            SampleCommand,
            SampleRepeatedCommand,
            SpriteAnimation,
            Uninitialized
        }

        public TimerEvent() : base()
        {
            this.name = TimerEvent.Name.Uninitialized;
            this.deltaTimeToTrigger = 0.0f;
            this.triggerTime = 0.0f;
            this.pCommand = null;
        }

        public void Set(TimerEvent.Name name, Command pCommand, float deltaTimeToTrigger)
        {
            this.name = name;
            this.deltaTimeToTrigger = deltaTimeToTrigger;
            this.triggerTime = TimerManager.GetCurrentTime() + this.deltaTimeToTrigger;
            this.pCommand = pCommand;
        }

        public void Process()
        {
            Debug.Assert(this.pCommand != null);
            this.pCommand.Execute(this.deltaTimeToTrigger);
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.deltaTimeToTrigger = 0.0f;
            this.triggerTime = 0.0f;
            this.pCommand = null;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
        }
    }
}