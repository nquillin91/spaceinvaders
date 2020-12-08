using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    public class SpriteBatchManager : Manager
    {
        private static SpriteBatchManager pSpriteBatchManager;
        private readonly SpriteBatch poCompareNode;
        
        private SpriteBatchManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (SpriteBatch)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pSpriteBatchManager == null)
            {
                pSpriteBatchManager = new SpriteBatchManager(reserveSize, growthSize);
            }
        }

        public static SpriteBatchManager GetInstance()
        {
            Debug.Assert(pSpriteBatchManager != null);

            return pSpriteBatchManager;
        }

        public static SpriteBatch Add(SpriteBatch.Name name, int reserveSize = 3, int growthSize = 1)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch spriteBatch = SpriteBatchManager.Find(name);

            // Preventing duplicates
            if (spriteBatch == null)
            {
                spriteBatch = (SpriteBatch)spriteBatchMan.BaseAddNode();
                Debug.Assert(spriteBatch != null);
                spriteBatch.Set(name, reserveSize, growthSize);
            }

            return spriteBatch;
        }

        public static void Remove(SpriteBatch spriteBatch)
        {
            Debug.Assert(spriteBatch != null);

            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();
            Debug.Assert(spriteBatchMan != null);

            spriteBatchMan.BaseRemove(spriteBatch);
        }

        public static void Remove(SpriteNode pSpriteNode)
        {
            Debug.Assert(pSpriteNode != null);
            SpriteNodeManager pSpriteNodeManager = pSpriteNode.GetNodeManager();

            Debug.Assert(pSpriteNodeManager != null);
            pSpriteNodeManager.Remove(pSpriteNode);
        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            spriteBatchMan.poCompareNode.SetName(name);

            SpriteBatch spriteBatch = (SpriteBatch)spriteBatchMan.BaseFind(spriteBatchMan.poCompareNode);

            return spriteBatch;
        }

        public static void Draw()
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch temp = (SpriteBatch)spriteBatchMan.poActiveList;

            while (temp != null)
            {
                temp.poSpriteNodeManager.Draw();

                temp = (SpriteBatch)temp.pNext;
            }
        }

        protected override DLink CreateNode()
        {
            SpriteBatch spriteBatch = new SpriteBatch();
            Debug.Assert(spriteBatch != null);

            return spriteBatch;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            SpriteBatch spriteBatchA = (SpriteBatch)pLinkA;
            SpriteBatch spriteBatchB = (SpriteBatch)pLinkB;

            if (spriteBatchA.GetName() == spriteBatchB.GetName())
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();
            Debug.Assert(spriteBatchMan != null);
            spriteBatchMan.BaseDestroy();
        }
    }
}
