using SpaceInvaders.Nodes;
using SpaceInvaders.Nodes.Sprites;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BoxSpriteManager : Manager
    {
        private static BoxSpriteManager pSpriteManager;
        private readonly BoxSprite poCompareNode;

        private BoxSpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (BoxSprite)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pSpriteManager == null)
            {
                pSpriteManager = new BoxSpriteManager(reserveSize, growthSize);
            }
        }

        private static BoxSpriteManager GetInstance()
        {
            Debug.Assert(pSpriteManager != null);

            return pSpriteManager;
        }

        public static BoxSprite Add(BoxSprite.Name name, float x, float y, float width, float height)
        {
            BoxSpriteManager spriteMan = BoxSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            BoxSprite sprite = (BoxSprite)BoxSpriteManager.Find(name);

            if (sprite == null)
            {
                sprite = (BoxSprite)spriteMan.BaseAddNode();
                sprite.Set(name, x, y, width, height);
            }

            Debug.Assert(sprite != null);

            return sprite;
        }

        public static BoxSprite Add(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color poColor)
        {
            BoxSpriteManager spriteMan = BoxSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            BoxSprite sprite = (BoxSprite)BoxSpriteManager.Find(name);

            if (sprite == null)
            {
                sprite = (BoxSprite)spriteMan.BaseAddNode();
                sprite.Set(name, x, y, width, height, poColor);
            }

            Debug.Assert(sprite != null);

            return sprite;
        }

        public static void Remove(BoxSprite sprite)
        {
            Debug.Assert(sprite != null);

            BoxSpriteManager spriteMan = BoxSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.BaseRemove(sprite);
        }

        public static BoxSprite Find(BoxSprite.Name name)
        {
            BoxSpriteManager spriteMan = BoxSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.poCompareNode.name = name;

            BoxSprite sprite = (BoxSprite)spriteMan.BaseFind(spriteMan.poCompareNode);

            return sprite;
        }
        protected override DLink CreateNode()
        {
            BoxSprite sprite = new BoxSprite();
            Debug.Assert(sprite != null);

            return sprite;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            BoxSprite spriteA = (BoxSprite)pLinkA;
            BoxSprite spriteB = (BoxSprite)pLinkB;

            if (spriteA.name == spriteB.name)
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            BoxSpriteManager spriteMan = BoxSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);
            spriteMan.BaseDestroy();
        }
    }
}