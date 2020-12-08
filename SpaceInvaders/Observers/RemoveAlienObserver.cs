using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observers
{
    class RemoveAlienObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {

            this.pSubject.pObjB.GetColObject().poColRect.Set(0, 0, 0, 0);
            this.pSubject.pObjB.Update();

            GameObject pParent = (GameObject)this.pSubject.pObjB.pParent;
            pParent.Update();

            this.pSubject.pObjB.Remove();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
