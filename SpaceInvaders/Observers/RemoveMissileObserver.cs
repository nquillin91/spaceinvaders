using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observers
{
    class RemoveMissileObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {

            this.pSubject.pObjA.GetColObject().poColRect.Set(0, 0, 0, 0);
            this.pSubject.pObjA.Update();

            GameObject pParent = (GameObject)this.pSubject.pObjA.pParent;
            pParent.Update();

            this.pSubject.pObjA.Remove();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
