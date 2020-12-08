using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class PlayerExplosionAnimationCommand : Command
    {
        ProxySprite pPlayerExplosionFrame1;

        public PlayerExplosionAnimationCommand(ProxySprite pPlayerExplosionFrame1)
        {
            this.pPlayerExplosionFrame1 = pPlayerExplosionFrame1;

            Debug.Assert(this.pPlayerExplosionFrame1 != null);
        }

        override public void Execute(float deltaTime)
        {
            SpriteNode pSpriteNode = this.pPlayerExplosionFrame1.GetSpriteNode();

            ProxySprite pDeadPlayerProxy = ProxySpriteManager.Add(GameSprite.Name.DeadPlayer2);
            SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
            pDeadPlayerProxy.x = this.pPlayerExplosionFrame1.x;
            pDeadPlayerProxy.y = this.pPlayerExplosionFrame1.y;
            pExplosionBatch.Attach(pDeadPlayerProxy);

            SpriteBatchManager.Remove(pSpriteNode);
            TimerManager.Add(TimerEvent.Name.PlayerExplosion2, new RemoveProxySprite(pDeadPlayerProxy), 0.25f);

            HUDManager.RemovePlayerLife();
        }
    }
}