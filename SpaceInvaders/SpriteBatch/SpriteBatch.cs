using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    public class SpriteBatch : DLink
    {
        private Name name;
        public SpriteNodeManager poSpriteNodeManager;

        public enum Name
        {
            Aliens,
            Player,
            Boxes,
            Shields,
            Explosions,
            HUD,
            Uninitialized
        }

        public SpriteBatch() : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.poSpriteNodeManager = new SpriteNodeManager();
        }

        public void Set(SpriteBatch.Name name, int reserveSize, int growthSize)
        {
            this.name = name;
            this.poSpriteNodeManager.Set(name, reserveSize, growthSize);
        }

        public void Set(SpriteBatch.Name name, SpriteNodeManager poSpriteNodeManager)
        {
            this.name = name;
            this.poSpriteNodeManager = poSpriteNodeManager;
        }

        public void SetName(SpriteBatch.Name name)
        {
            this.name = name;
        }

        public SpriteBatch.Name GetName()
        {
            return this.name;
        }

        public void Attach(SpriteBase pNode)
        {
            Debug.Assert(pNode != null);

            // Go to Man, get a node from reserve, add to active, return it
            SpriteNode pSpriteNode = (SpriteNode)this.poSpriteNodeManager.Attach(pNode);
            Debug.Assert(pSpriteNode != null);

            // Initialize SpriteBatchNode
            pSpriteNode.Set(pNode, this.poSpriteNodeManager);

            this.poSpriteNodeManager.SetSpriteBatch(this);
        }

        public override void Wash()
        {
            base.Wash();

            //poSpriteNodeManager.Destroy()
            poSpriteNodeManager = null;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            if (this.poSpriteNodeManager != null)
            {
                this.poSpriteNodeManager.Destroy();
            }
        }
    }
}