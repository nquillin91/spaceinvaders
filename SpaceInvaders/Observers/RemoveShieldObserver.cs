using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class RemoveShieldObserver : ColObserver
    {
        IrrKlang.ISoundEngine pSndEngine;

        public RemoveShieldObserver(IrrKlang.ISoundEngine pEng)
        {
            Debug.Assert(pEng != null);
            this.pSndEngine = pEng;
        }

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
                    //pC.Remove();
                }
            }

            pSndEngine.SoundVolume = 0.2f;
            IrrKlang.ISound pSnd = pSndEngine.Play2D("explosion.wav");
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