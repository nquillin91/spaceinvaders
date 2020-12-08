using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    public class SpriteNode : DLink
    {
        public SpriteBase pSprite;
        private SpriteNodeManager pBackSpriteNodeMan;

        public SpriteNode() : base()
        {
            this.pSprite = null;
        }

        public void Set(SpriteBase pNode, SpriteNodeManager pSpriteNodeManager)
        {
            Debug.Assert(pNode != null);
            this.pSprite = pNode;

            Debug.Assert(pSprite != null);
            this.pSprite.SetSpriteNode(this);

            Debug.Assert(pSpriteNodeManager != null);
            this.pBackSpriteNodeMan = pSpriteNodeManager;
        }

        public SpriteNodeManager GetNodeManager()
        {
            Debug.Assert(this.pBackSpriteNodeMan != null);
            return this.pBackSpriteNodeMan;
        }

        public override void Wash()
        {
            base.Wash();

            this.pSprite = null;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}