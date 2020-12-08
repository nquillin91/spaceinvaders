using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    public class SampleRepeatedCommand : Command
    {
        private String pString;
        private float pRepeatDelta;

        public SampleRepeatedCommand(String txt, float repeatDelta)
        {
            this.pString = txt;
            this.pRepeatDelta = repeatDelta;
        }

        public override void Execute(float deltaTime)
        {
            Debug.WriteLine(" {0} time:{1} ", this.pString, TimerManager.GetCurrentTime());

            TimerManager.Add(TimerEvent.Name.SampleRepeatedCommand, this, this.pRepeatDelta);
        }
    }
}
