using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class UFOExplosionObserver : ColObserver
    {
        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            AlienCategory pUFO = (AlienCategory)this.pSubject.pObjB;

            ProxySprite pDeadUFOProxy = ProxySpriteManager.Add(GameSprite.Name.DeadUFO);
            SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
            pDeadUFOProxy.x = pUFO.x;
            pDeadUFOProxy.y = pUFO.y;
            pExplosionBatch.Attach(pDeadUFOProxy);

            TimerManager.Add(TimerEvent.Name.AlienDeath, new RemoveProxySprite(pDeadUFOProxy), 0.25f);

            AudioSource pSound = SoundManager.Find(AudioSource.Name.DeathUFO);
            Debug.Assert(pSound != null);
            pSound.Play();

            this.UpdateScore(this.pSubject.pObjB);
        }

        private void UpdateScore(GameObject pGameObj)
        {
            AlienCategory pUFO = (AlienCategory)pGameObj;
            HUDManager.UpdateScore(pUFO.GetPoints());
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}