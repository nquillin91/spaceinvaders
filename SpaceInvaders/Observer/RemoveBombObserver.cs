using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observers
{
    class RemoveBombObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            Bomb pBomb = (Bomb)this.pSubject.pObjA;
            AlienColumn pAlienColumn = pBomb.GetAlienColumn();
            pAlienColumn.pBomb = null;

            pBomb.Remove();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}