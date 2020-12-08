using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class RemoveProxySprite : Command
    {
        ProxySprite pObjToBeRemoved;

        public RemoveProxySprite(ProxySprite pObjToBeRemoved)
        {
            this.pObjToBeRemoved = pObjToBeRemoved;

            Debug.Assert(this.pObjToBeRemoved != null);
        }

        override public void Execute(float deltaTime)
        {
            SpriteNode pSpriteNode = this.pObjToBeRemoved.GetSpriteNode();
            SpriteBatchManager.Remove(pSpriteNode);
        }
    }
}