using SpaceInvaders.Composites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    class GameObjectManager : Manager
    {
        private static GameObjectManager pGameObjectManagerInstance = null;
        private readonly GameObjectNode poNodeCompare;
        private readonly NullGameObject poNullGameObject;

        private GameObjectManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = new GameObjectNode();
            this.poNullGameObject = new NullGameObject();

            this.poNodeCompare.poGameObj = this.poNullGameObject;
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
            pMan.poNodeCompare.poGameObj.name = name;

            GameObjectNode pNode = (GameObjectNode)pMan.BaseFind(pMan.poNodeCompare);
            Debug.Assert(pNode != null);

            return pNode.poGameObj;
        }

        public static GameObjectNode Find(GameObject.Name name, uint instanceId)
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes
            pMan.poNodeCompare.poGameObj.name = name;
            pMan.poNodeCompare.poGameObj.instanceId = instanceId;

            GameObjectNode pNode = (GameObjectNode)pMan.BaseFind(pMan.poNodeCompare);
            Debug.Assert(pNode != null);

            return pNode;
        }

        public static void Remove(GameObjectNode pNode)
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.BaseRemove(pNode);
        }

        public static void Remove(GameObject pNode)
        {
            Debug.Assert(pNode != null);
            GameObjectManager pMan = GameObjectManager.GetInstance();

            GameObject pTmp = pNode;
            GameObject pRoot = null;
            while (pTmp != null)
            {
                pRoot = pTmp;
                pTmp = (GameObject)Iterator.GetParent(pTmp);
            }

            GameObjectNode pTree = (GameObjectNode)pMan.poActiveList;

            while (pTree != null)
            {
                if (pTree.poGameObj == pRoot)
                {
                    // found it
                    break;
                }
                // Goto Next tree
                pTree = (GameObjectNode)pTree.pNext;
            }

            Debug.Assert(pTree != null);
            Debug.Assert(pTree.poGameObj != null);
            Debug.Assert(pTree.poGameObj != pNode);

            GameObject pParent = (GameObject)Iterator.GetParent(pNode);
            Debug.Assert(pParent != null);

            // Make sure there is no child before the delete
            GameObject pChild = (GameObject)Iterator.GetChild(pNode);
            Debug.Assert(pChild == null);

            // remove the node
            pParent.Remove(pNode);
            pParent.Update();
        }

        public static void Update()
        {
            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pGameObjectNode = (GameObjectNode)pMan.poActiveList;

            while (pGameObjectNode != null)
            {
                ReverseIterator pRev = new ReverseIterator(pGameObjectNode.poGameObj);

                Component pNode = pRev.First();
                while (!pRev.IsDone())
                {
                    GameObject pGameObj = (GameObject)pNode;

                    pGameObj.Update();

                    pNode = pRev.Next();
                }

                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
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

            if (pDataA.poGameObj.GetName() == pDataB.poGameObj.GetName()
                && pDataA.poGameObj.instanceId == pDataB.poGameObj.instanceId)
            {
                status = true;
            }

            return status;
        }
    }
}
