using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerStateNoMoveLeft : PlayerState
	{
        public override void Handle(PlayerShip pShip)
        {
            pShip.SetPlayerState(PlayerManager.State.FreeMove);
        }

        public override void MoveRight(PlayerShip pShip)
        {
            this.Handle(pShip);
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(PlayerShip pShip)
        {
        }
    }
}
