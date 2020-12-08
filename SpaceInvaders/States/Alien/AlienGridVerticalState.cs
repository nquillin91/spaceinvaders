using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.States.Alien
{
    public abstract class AlienGridVerticalState
    {
        public abstract void Handle(AlienGrid pAlienGrid);

        public abstract void MoveVertically(AlienGrid pAlienGrid);
    }
}
