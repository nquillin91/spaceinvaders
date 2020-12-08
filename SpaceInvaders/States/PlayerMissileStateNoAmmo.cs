using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerMissileStateNoAmmo : PlayerMissileState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetMissileState(PlayerManager.MissileState.Ready);
        }

        public override void Shoot(PlayerShip pShip)
        {
        }
    }
}