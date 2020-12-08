using SpaceInvaders.Managers;
using SpaceInvaders.Nodes.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Nodes
{
    class SpriteBatch : DLink
    {
        public Name name;
        public int priority;
        public SpriteNodeManager poSpriteNodeManager;

        public enum Name
        {
            Birds,
            Stitch,
            Boxes,
            Aliens,
            Uninitialized
        }

        public SpriteBatch() : base()
        {
            // TODO: Need to fix args
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