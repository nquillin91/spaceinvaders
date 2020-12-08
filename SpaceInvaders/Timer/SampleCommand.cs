using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    public class SampleCommand : Command
    {
        private String pString;

        public SampleCommand(String txt)
        {
            this.pString = txt;
        }

        public override void Execute(float deltaTime)
        {
            Debug.WriteLine(" {0} time:{1} ", this.pString, TimerManager.GetCurrentTime());
        }
    }
}
