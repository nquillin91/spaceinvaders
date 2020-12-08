using SpaceInvaders.Nodes;
using SpaceInvaders.Nodes.Sprites;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSpriteManager : Manager
    {
        private static GameSpriteManager pSpriteManager;
        private readonly GameSprite poCompareNode;

        private GameSpriteManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (GameSprite)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pSpriteManager == null)
            {
                pSpriteManager = new GameSpriteManager(reserveSize, growthSize);
            }
        }

        private static GameSpriteManager GetInstance()
        {
            Debug.Assert(pSpriteManager != null);

            return pSpriteManager;
        }

        public static GameSprite Add(GameSprite.Name name, Image.Name imageName, float x, float y, float width, float height)
        {
            GameSpriteManager spriteMan = GameSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            GameSprite sprite = (GameSprite) GameSpriteManager.Find(name);

            if (sprite == null)
            {
                Image pImage = ImageManager.Find(imageName);
                Debug.Assert(pImage != null);

                sprite = (GameSprite)spriteMan.BaseAddNode();
                sprite.Set(name, pImage, x, y, width, height);
            }

            Debug.Assert(sprite != null);

            return sprite;
        }

        public static void Remove(GameSprite sprite)
        {
            Debug.Assert(sprite != null);

            GameSpriteManager spriteMan = GameSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.BaseRemove(sprite);
        }

        public static GameSprite Find(GameSprite.Name name)
        {
            GameSpriteManager spriteMan = GameSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);

            spriteMan.poCompareNode.name = name;

            GameSprite sprite = (GameSprite)spriteMan.BaseFind(spriteMan.poCompareNode);

            return sprite;
        }
        protected override DLink CreateNode()
        {
            GameSprite sprite = new GameSprite();
            Debug.Assert(sprite != null);

            return sprite;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            GameSprite spriteA = (GameSprite)pLinkA;
            GameSprite spriteB = (GameSprite)pLinkB;

            if (spriteA.name == spriteB.name)
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            GameSpriteManager spriteMan = GameSpriteManager.GetInstance();
            Debug.Assert(spriteMan != null);
            spriteMan.BaseDestroy();
        }
    }
}
