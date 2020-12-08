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
    class AlienGridStateMoveHorizontally : AlienGridHorizontalState
    {
        public override void Handle(AlienGrid pAlienGrid)
        {
            pAlienGrid.SetHorizontalState(Aliens.AlienManager.HorizontalState.NoMoveHorizontally);
        }

        public override void MoveHorizontally(AlienGrid pAlienGrid)
        {
            ForwardIterator iterator = new ForwardIterator(pAlienGrid);

            Component pNode = iterator.First();
            while (!iterator.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;

                pGameObj.x += AlienManager.GetCurrentSpeed() * AlienManager.GetCurrentDirection();

                pNode = iterator.Next();
            }

            this.Handle(pAlienGrid);
        }
    }
}
