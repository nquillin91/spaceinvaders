using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class RemoveMissileObserver : ColObserver
    {
        private GameObject pMissile;

        public RemoveMissileObserver()
        {
            this.pMissile = null;
        }

        public RemoveMissileObserver(RemoveMissileObserver m)
        {
            this.pMissile = m.pMissile;
        }

        public override void Notify()
        {
            this.pMissile = (Missile)this.pSubject.pObjA;
            Debug.Assert(this.pMissile != null);
            if (this.pMissile.bMarkForDeath == false)
            {
                this.pMissile.bMarkForDeath = true;
                ((Missile)this.pMissile).delta = 0.0f;

                RemoveMissileObserver pObserver = new RemoveMissileObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            this.pMissile.Remove();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}