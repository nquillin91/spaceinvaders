using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class MissileExplosionObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            Missile pMissile = (Missile)this.pSubject.pObjA;

            ProxySprite pDeadMissileProxy = ProxySpriteManager.Add(GameSprite.Name.DeadMissile);
            SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
            pDeadMissileProxy.x = pMissile.x;
            pDeadMissileProxy.y = pMissile.y;
            pExplosionBatch.Attach(pDeadMissileProxy);

            TimerManager.Add(TimerEvent.Name.MissileReset, new RemoveProxySprite(pDeadMissileProxy), 0.25f);

            AudioSource pSound = SoundManager.Find(AudioSource.Name.MissileExplosion);
            Debug.Assert(pSound != null);
            pSound.Play();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}