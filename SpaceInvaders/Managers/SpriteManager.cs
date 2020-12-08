using SpaceInvaders.Nodes;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager : Manager
    {
        private static SpriteManager pSpriteManager;
        private readonly Sprite poCompareNode;

        private SpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (Sprite)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pSpriteManager == null)
            {
                pSpriteManager = new SpriteManager(reserveSize, growthSize);
            }
        }

        private static SpriteManager GetInstance()
        {
            Debug.Assert(pSpriteManager != null);

            return pSpriteManager;
        }

        public static Sprite Add(Sprite.Name name, Image.Name imageName, float x, float y, float width, float height)
        {
            SpriteManager spriteMan = SpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            Image pImage = ImageManager.Find(imageName);
            Debug.Assert(pImage != null);

            Sprite sprite = (Sprite)spriteMan.BaseAddNode();

            sprite.Set(name, pImage, x, y, width, height);

            return sprite;
        }

        public static void Remove(Sprite sprite)
        {
            Debug.Assert(sprite != null);

            SpriteManager spriteMan = SpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.BaseRemove(sprite);
        }

        public static Sprite FindFirst(Sprite.Name name)
        {
            SpriteManager spriteMan = SpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.poCompareNode.name = name;

            Sprite sprite = (Sprite)spriteMan.BaseFind(spriteMan.poCompareNode);
            Debug.Assert(sprite != null);

            return sprite;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Sprite spriteA = (Sprite)pLinkA;
            Sprite spriteB = (Sprite)pLinkB;

            if (spriteA.name == spriteB.name &&
                spriteA.pImage == spriteB.pImage &&
                spriteA.poRect == spriteB.poRect)
            {
                return true;
            }

            return false;
        }

        protected override DLink CreateNode()
        {
            Sprite sprite = new Sprite(Sprite.Name.Uninitialized);
            Debug.Assert(sprite != null);

            return sprite;
        }
    }
}
