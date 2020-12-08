using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerMissileStateReady : PlayerMissileState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetMissileState(PlayerManager.MissileState.NoAmmo);
        }

        public override void Shoot(PlayerShip pShip)
        {
            Missile pMissile = PlayerManager.ActivateMissile();

            pMissile.SetPosition(pShip.x, pShip.y + 20);

            this.Handle(pShip);
        }
    }
}