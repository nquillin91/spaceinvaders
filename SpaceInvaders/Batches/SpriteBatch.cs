using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    class SpriteBatch : DLink
    {
        private Name name;
        public int priority;
        public SpriteNodeManager poSpriteNodeManager;

        public enum Name
        {
            Aliens,
            Uninitialized
        }

        public SpriteBatch() : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.priority = 0;
            this.poSpriteNodeManager = new SpriteNodeManager();
        }

        public void Set(SpriteBatch.Name name, int reserveSize, int growthSize, int priority)
        {
            this.name = name;
            this.priority = priority;
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

        public void Attach(GameSprite.Name name)
        {
            Debug.Assert(this.poSpriteNodeManager != null);

            this.poSpriteNodeManager.Attach(name);
        }

        public void Attach(BoxSprite.Name name)
        {
            Debug.Assert(this.poSpriteNodeManager != null);

            this.poSpriteNodeManager.Attach(name);
        }

        public void Attach(ProxySprite proxySprite)
        {
            Debug.Assert(this.poSpriteNodeManager != null);

            this.poSpriteNodeManager.Attach(proxySprite);
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