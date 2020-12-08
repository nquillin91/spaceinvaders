using SpaceInvaders.Aliens;
using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class AlienMoveHorizontallyCommand : Command
    {
        public override void Execute(float deltaTime)
        {
            AlienManager.GetAlienGrid().SetHorizontalState(AlienManager.HorizontalState.MoveHorizontally);

            // Add itself back to timer
            TimerManager.Add(TimerEvent.Name.AliensMove, this, deltaTime);
        }
    }
}