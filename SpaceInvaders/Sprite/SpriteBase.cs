using SpaceInvaders.Batches;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public abstract class SpriteBase : DLink
    {
        // This is used to maintain a reference for deletion
        private SpriteNode pBackSpriteNode;

        public SpriteBase() : base()
        {
            this.pBackSpriteNode = null;
        }

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }

        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }

        public abstract void Update();

        public abstract void Render();

        public override abstract void Dump();
    }
}