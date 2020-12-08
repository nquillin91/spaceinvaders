using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class ResetPlayerCommand : Command
    {
        override public void Execute(float deltaTime)
        {
            PlayerManager.Create();
            AlienManager.GetAlienGrid().ToggleHaltMovement();
        }
    }
}