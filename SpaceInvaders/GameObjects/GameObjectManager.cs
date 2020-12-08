using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectManager : Manager
    {
        private static GameObjectManager pGameObjectManagerInstance = null;
        private GameObjectNode poNodeCompare;
        private readonly NullGameObject poNullGameObject;

        private GameObjectManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new GameObjectNode();
            this.poNullGameObject = new NullGameObject();

            this.poNodeCompare.pGameObj = this.poNullGameObject;
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pGameObjectManagerInstance == null)
            {
                pGameObjectManagerInstance = new GameObjectManager(reserveSize, growthSize);
            }
        }

        public static GameObjectManager GetInstance()
        {
            Debug.Assert(pGameObjectManagerInstance != null);

            return pGameObjectManagerInstance;
        }

        public static void Destroy()
        {

        }

        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.BaseAddNode();
            Debug.Assert(pNode != null);

            pNode.Set(pGameObject);
            return pNode;
        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes
            pMan.poNodeCompare.pGameObj.name = name;

            GameObjectNode pNode = (GameObjectNode)pMan.BaseFind(pMan.poNodeCompare);
            Debug.Assert(pNode != null);

            return pNode.pGameObj;
        }

        public static void Remove(GameObjectNode pNode)
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.BaseRemove(pNode);
        }

        public static void Update()
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.poActiveList;

            while (pNode != null)
            {
                // Update the node
                Debug.Assert(pNode.pGameObj != null);

                pNode.pGameObj.Update();

                pNode = (GameObjectNode)pNode.pNext;
            }

        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override DLink CreateNode()
        {
            DLink pNode = new GameObjectNode();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            GameObjectNode pDataA = (GameObjectNode)pLinkA;
            GameObjectNode pDataB = (GameObjectNode)pLinkB;

            Boolean status = false;

            if (pDataA.pGameObj.GetName() == pDataB.pGameObj.GetName())
            {
                status = true;
            }

            return status;
        }
    }
}
