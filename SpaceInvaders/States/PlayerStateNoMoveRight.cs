using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerStateNoMoveRight : PlayerState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetPlayerState(PlayerManager.State.FreeMove);
        }

        public override void MoveRight(PlayerShip pShip)
        {
        }

        public override void MoveLeft(PlayerShip pShip)
        {
            this.Handle(pShip);
            pShip.x -= pShip.shipSpeed;
        }
    }
}
