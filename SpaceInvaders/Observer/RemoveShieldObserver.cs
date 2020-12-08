using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sound;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class RemoveShieldObserver : ColObserver
    {

        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            GameObject pA = this.pSubject.pObjB;
            Debug.Assert(pA != null);
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            pA.Remove();

            if (CheckParent(pB) == true)
            {
                GameObject pC = (GameObject)Iterator.GetParent(pB);
                pB.Remove();

                if (CheckParent(pC) == true)
                {
                    pC.Remove();
                }
            }
        }

        private bool CheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}