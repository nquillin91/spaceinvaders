using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    class SpriteNodeManager : Manager
    {
        private SpriteBatch.Name associatedBatchName;
        private readonly SpriteNode poCompareNode;

        public SpriteNodeManager(int reserveSize = 3, int growthSize = 1) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (SpriteNode)this.CreateNode();
        }

        public void Set(SpriteBatch.Name name, int reserveSize, int growthSize)
        {
            this.associatedBatchName = name;
            this.SetManagerDefaults(reserveSize, growthSize);
        }

        public void Attach(GameSprite.Name name)
        {
            SpriteNode spriteNode = (SpriteNode)this.BaseAddNode();
            Debug.Assert(spriteNode != null);

            spriteNode.Set(name);
        }

        public void Attach(BoxSprite.Name name)
        {
            SpriteNode spriteNode = (SpriteNode)this.BaseAddNode();
            Debug.Assert(spriteNode != null);

            spriteNode.Set(name);
        }

        public void Attach(ProxySprite proxySprite)
        {
            SpriteNode spriteNode = (SpriteNode)this.BaseAddNode();
            Debug.Assert(spriteNode != null);

            spriteNode.Set(proxySprite);
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
