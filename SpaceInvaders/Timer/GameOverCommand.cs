using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Scenes;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class GameOverCommand : Command
    {
        override public void Execute(float deltaTime)
        {
            SceneManager.MarkForGameOver();
        }
    }
}