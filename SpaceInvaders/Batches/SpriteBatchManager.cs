using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Batches
{
    class SpriteBatchManager : Manager
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

        public static SpriteBatch Add(SpriteBatch.Name name, int reserveSize, int growthSize, int priority)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch spriteBatch = SpriteBatchManager.Find(name);

            // Preventing duplicates
            if (spriteBatch == null)
            {
                spriteBatch = (SpriteBatch)spriteBatchMan.AddNodeByPriority(priority);
                spriteBatch.Set(name, reserveSize, growthSize, priority);
            }

            return spriteBatch;
        }

        public static void UpdatePriority(SpriteBatch.Name name, int priority)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch spriteBatch = SpriteBatchManager.Find(name);
            Debug.Assert(spriteBatch != null);

            SpriteBatch newSpriteBatch = (SpriteBatch)spriteBatchMan.AddNodeByPriority(priority);
            Debug.Assert(newSpriteBatch != null);

            newSpriteBatch.Set(name, spriteBatch.poSpriteNodeManager);

            SpriteBatchManager.Remove(spriteBatch);
        }

        public static void Remove(SpriteBatch spriteBatch)
        {
            Debug.Assert(spriteBatch != null);

            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();
            Debug.Assert(spriteBatchMan != null);

            spriteBatchMan.BaseRemove(spriteBatch);
        }

        public static void Attach(SpriteBatch.Name name, GameSprite.Name spriteName)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch spriteBatch = SpriteBatchManager.Find(name);
            Debug.Assert(spriteBatch != null);

            spriteBatch.Attach(spriteName);
        }

        public static void Attach(SpriteBatch.Name name, BoxSprite.Name spriteName)
        {
            SpriteBatchManager spriteBatchMan = SpriteBatchManager.GetInstance();

            SpriteBatch spriteBatch = SpriteBatchManager.Find(name);
            Debug.Assert(spriteBatch != null);

            spriteBatch.Attach(spriteName);
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

        private DLink AddNodeByPriority(int priority)
        {
            if (this.poReserveList.size == 0)
            {
                this.GenerateReserveNodes(this.growthSize);
            }

            DLink pLink = DLink.RemoveFromFront(ref this.poReserveList);

            Debug.Assert(pLink != null);
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);

            DLink temp = this.poActiveList;

            if (temp == null)
            {
                DLink.AddFirst(ref this.poActiveList, pLink);
            } else
            {
                while (temp != null)
                {
                    if (priority <= ((SpriteBatch)temp).priority)
                    {
                        DLink.InsertBeforeNode(ref this.poActiveList, ref temp, ref pLink);
                        break;
                    }

                    if (temp.pNext == null)
                    {
                        DLink.InsertAfterNode(ref this.poActiveList, ref temp, ref pLink);
                        break;
                    }

                    temp = temp.pNext;
                }
            }

            this.poActiveList.size++;
            this.poReserveList.size--;

            return pLink;
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
