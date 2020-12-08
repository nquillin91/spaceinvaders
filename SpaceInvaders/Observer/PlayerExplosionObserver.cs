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
    class PlayerExplosionObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            PlayerShip pShip = (PlayerShip)this.pSubject.pObjB;

            ProxySprite pDeadPlayerProxy = ProxySpriteManager.Add(GameSprite.Name.DeadPlayer1);
            SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
            pDeadPlayerProxy.x = pShip.x;
            pDeadPlayerProxy.y = pShip.y;
            pExplosionBatch.Attach(pDeadPlayerProxy);

            TimerManager.Add(TimerEvent.Name.PlayerExplosion1, new PlayerExplosionAnimationCommand(pDeadPlayerProxy), 0.25f);

            AudioSource pSound = SoundManager.Find(AudioSource.Name.DeathPlayer);
            Debug.Assert(pSound != null);
            pSound.Play();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}