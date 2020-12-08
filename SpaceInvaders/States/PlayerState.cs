using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.States
{
    public abstract class PlayerState
    {
        public abstract void Handle(PlayerShip pShip);

        public abstract void MoveRight(PlayerShip pShip);

        public abstract void MoveLeft(PlayerShip pShip);

        public abstract void Shoot(PlayerShip pShip);
    }
}
