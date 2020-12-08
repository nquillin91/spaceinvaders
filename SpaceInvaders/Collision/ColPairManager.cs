using SpaceInvaders.GameObjects;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Collision
{
    class ColPairManager : Manager
    {
        private static ColPairManager pColPairManagerInstance;
        private ColPair pActiveColPair;
        private readonly ColPair poNodeCompare;

        private ColPairManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new ColPair();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pColPairManagerInstance == null)
            {
                pColPairManagerInstance = new ColPairManager(reserveSize, growthSize);
            }
        }

        public static ColPairManager GetInstance()
        {
            Debug.Assert(pColPairManagerInstance != null);

            return pColPairManagerInstance;
        }

        public static void Destroy()
        {

        }

        public static ColPair Add(ColPair.Name colpairName, GameObject treeRootA, GameObject treeRootB)
        {
            ColPairManager pMan = ColPairManager.GetInstance();
            Debug.Assert(pMan != null);

            // Go to Man, get a node from reserve, add to active, return it
            ColPair pColPair = (ColPair)pMan.BaseAddNode();
            Debug.Assert(pColPair != null);

            pColPair.Set(colpairName, treeRootA, treeRootB);

            return pColPair;
        }

        public static void Process()
        {
            // get the singleton
            ColPairManager pMan = ColPairManager.GetInstance();

            ColPair pColPair = (ColPair)pMan.poActiveList;

            while (pColPair != null)
            {
                pMan.pActiveColPair = pColPair;

                // do the check for a single pair
                pColPair.Process();

                // advance to next
                pColPair = (ColPair)pColPair.pNext;
            }
        }

        static public ColPair GetActiveColPair()
        {
            ColPairManager pMan = ColPairManager.GetInstance();

            return pMan.pActiveColPair;
        }

        public static ColPair Find(ColPair.Name name)
        {
            ColPairManager pMan = ColPairManager.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeCompare.SetName(name);

            ColPair pData = (ColPair)pMan.BaseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(ColPair pNode)
        {
            ColPairManager pMan = ColPairManager.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.BaseRemove(pNode);
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override DLink CreateNode()
        {
            DLink pNode = new ColPair();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ColPair pDataA = (ColPair)pLinkA;
            ColPair pDataB = (ColPair)pLinkB;

            Boolean status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }
    }
}