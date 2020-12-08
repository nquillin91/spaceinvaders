using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    public class SpriteNodeManager : Manager
    {
        private SpriteBatch.Name name;
        private SpriteBatch pBackSpriteBatch;
        private readonly SpriteNode poCompareNode;

        public SpriteNodeManager(int reserveSize = 3, int growthSize = 1) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (SpriteNode)this.CreateNode();
            this.pBackSpriteBatch = null;
        }

        public void Set(SpriteBatch.Name name, int reserveSize, int growthSize)
        {
            this.name = name;
            this.SetManagerDefaults(reserveSize, growthSize);
        }

        public SpriteNode Attach(Sprite pNode)
        {
            // Go to Man, get a node from reserve, add to active, return it
            SpriteNode pSBNode = (SpriteNode)this.BaseAddNode();
            Debug.Assert(pSBNode != null);

            // Initialize SpriteBatchNode
            pSBNode.Set(pNode, this);

            return pSBNode;
        }

        public void Remove(SpriteNode pNode)
        {
            Debug.Assert(pNode != null);
            this.BaseRemove(pNode);
        }

        public SpriteBatch GetSpriteBatch()
        {
            return this.pBackSpriteBatch;
        }

        public void SetSpriteBatch(SpriteBatch _pSpriteBatch)
        {
            this.pBackSpriteBatch = _pSpriteBatch;
        }

        public void Draw()
        {
            SpriteNode temp = (SpriteNode)this.poActiveList;

            while (temp != null)
            {
                temp.pSprite.Update();
                temp.pSprite.Render();

                temp = (SpriteNode)temp.pNext;
            }
        }

        protected override DLink CreateNode()
        {
            SpriteNode spriteNode = new SpriteNode();
            Debug.Assert(spriteNode != null);

            return spriteNode;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            SpriteNode spriteNodeA = (SpriteNode)pLinkA;
            SpriteNode spriteNodeB = (SpriteNode)pLinkB;

            if (spriteNodeA == spriteNodeB)
            {
                return true;
            }

            return false;
        }

        public void Destroy()
        {
            base.BaseDestroy();
        }
    }
}
