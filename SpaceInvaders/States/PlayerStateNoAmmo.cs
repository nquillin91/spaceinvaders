﻿using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerStateNoAmmo : PlayerState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetState(PlayerManager.State.Active);
        }

        public override void MoveRight(PlayerShip pShip)
        {
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(PlayerShip pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }

        public override void Shoot(PlayerShip pShip)
        {
        }
    }
}