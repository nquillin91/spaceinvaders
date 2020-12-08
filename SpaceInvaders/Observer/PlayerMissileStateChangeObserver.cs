using SpaceInvaders.Collision;
using SpaceInvaders.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observers
{
    class PlayerMissileStateChangeObserver : ColObserver
    {
        public override void Notify()
        {
            PlayerShip pShip = PlayerManager.GetShip();
            pShip.HandleMissileState();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
