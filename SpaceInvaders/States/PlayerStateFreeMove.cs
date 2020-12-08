using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using Debug = System.Diagnostics.Debug;

namespace SpaceInvaders.States
{
	class PlayerStateFreeMove : PlayerState
	{
        public override void Handle(PlayerShip pShip)
        {
        }

        public override void MoveRight(PlayerShip pShip)
        {
            pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(PlayerShip pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }
    }
}
