using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerStateActive : PlayerState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetState(PlayerManager.State.NoAmmo);
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
            Missile pMissile = PlayerManager.ActivateMissile();

            pMissile.SetPosition(pShip.x, pShip.y + 20);

            this.Handle(pShip);
        }
    }
}
