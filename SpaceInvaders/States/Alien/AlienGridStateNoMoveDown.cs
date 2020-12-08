using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.States.Alien
{
    class AlienGridStateNoMoveDown : AlienGridVerticalState
    {
        public override void Handle(AlienGrid pAlienGrid)
        {
            pAlienGrid.SetVerticalState(Aliens.AlienManager.State.MoveDown);
        }

        public override void MoveVertically(AlienGrid pAlienGrid)
        {
        }
    }
}
