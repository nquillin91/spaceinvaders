using SpaceInvaders.Aliens;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.States.Alien
{
    class AlienGridStateMoveDown : AlienGridVerticalState
    {
        public override void Handle(AlienGrid pAlienGrid)
        {
            pAlienGrid.SetVerticalState(Aliens.AlienManager.State.NoMoveDown);
        }

        public override void MoveVertically(AlienGrid pAlienGrid)
        {
            ForwardIterator iterator = new ForwardIterator(pAlienGrid);

            Component pNode = iterator.First();
            while (!iterator.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;

                pGameObj.y -= AlienManager.GetCurrentSpeed();

                pNode = iterator.Next();
            }

            this.Handle(pAlienGrid);
        }
    }
}
