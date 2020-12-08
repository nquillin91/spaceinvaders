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
    class AlienExplosionObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            AlienCategory pAlien = (AlienCategory)this.pSubject.pObjB;

            ProxySprite pDeadAlienProxy = ProxySpriteManager.Add(GameSprite.Name.DeadAlien);
            SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
            pDeadAlienProxy.x = pAlien.x;
            pDeadAlienProxy.y = pAlien.y;
            pExplosionBatch.Attach(pDeadAlienProxy);

            TimerManager.Add(TimerEvent.Name.AlienDeath, new RemoveProxySprite(pDeadAlienProxy), 0.25f);

            AudioSource pSound = SoundManager.Find(AudioSource.Name.DeathAlien);
            Debug.Assert(pSound != null);
            pSound.Play();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}