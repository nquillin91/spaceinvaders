using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    class ProxySpriteManager : Manager
    {
        private static ProxySpriteManager pProxyManagerInstance = null;
        private ProxySprite poNodeCompare;

        private ProxySpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poNodeCompare = (ProxySprite)this.CreateNode();
        }

        ~ProxySpriteManager()
        {
            this.poNodeCompare = null;
            ProxySpriteManager.pProxyManagerInstance = null;
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pProxyManagerInstance == null)
            {
                pProxyManagerInstance = new ProxySpriteManager(reserveSize, growthSize);
            }
        }

        private static ProxySpriteManager GetInstance()
        {
            Debug.Assert(pProxyManagerInstance != null);

            return pProxyManagerInstance;
        }

        public static ProxySprite Add(GameSprite.Name name)
        {
            ProxySpriteManager pMan = ProxySpriteManager.GetInstance();
            Debug.Assert(pMan != null);

            ProxySprite pNode = (ProxySprite)pMan.BaseAddNode();
            Debug.Assert(pNode != null);

            pNode.Set(name);

            return pNode;
        }

        public static void Remove(GameSprite pNode)
        {
            ProxySpriteManager pMan = ProxySpriteManager.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.BaseRemove(pNode);
        }

        public static ProxySprite Find(ProxySprite.Name name)
        {
            ProxySpriteManager pMan = ProxySpriteManager.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeCompare.SetName(name);

            ProxySprite pData = (ProxySprite)pMan.BaseFind(pMan.poNodeCompare);
            return pData;
        }

        protected override DLink CreateNode()
        {
            DLink pNode = new ProxySprite();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ProxySprite pDataA = (ProxySprite)pLinkA;
            ProxySprite pDataB = (ProxySprite)pLinkB;

            Boolean status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }
    }
}
