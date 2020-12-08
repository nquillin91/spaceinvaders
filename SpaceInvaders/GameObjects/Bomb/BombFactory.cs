
using SpaceInvaders.Batches;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    class BombFactory
    {
        private readonly SpriteBatch pBoxSpriteBatch;
        private readonly SpriteBatch pSpriteBatch;

        public BombFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pBoxSpriteBatch != null);
        }

        ~BombFactory()
        {
        }

        public GameObject Create(float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pBomb = null;

            FallStrategy.Type type = GetRandomStrategy();

            switch (type)
            {
                case FallStrategy.Type.Dagger:
                    pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombDagger, new FallDagger(), posX, posY);
                    break;

                case FallStrategy.Type.Straight:
                    pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombStraight, new FallStraight(), posX, posY);
                    break;

                case FallStrategy.Type.ZigZag:
                    pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombZigZag, new FallZigZag(), posX, posY);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            pBomb.ActivateCollisionSprite(this.pBoxSpriteBatch);
            pBomb.ActivateGameSprite(this.pSpriteBatch);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);
            pBombRoot.Add(pBomb);

            return pBomb;
        }

        public FallStrategy.Type GetRandomStrategy()
        {
            Random pRandom = new Random();

            int value = pRandom.Next(0, 3);

            switch(value)
            {
                case 0:
                    return FallStrategy.Type.Dagger;
                case 1:
                    return FallStrategy.Type.Straight;
                case 2:
                    return FallStrategy.Type.ZigZag;
                default:
                    Debug.Assert(false);
                    return FallStrategy.Type.Straight;
            }
        }
    }
}
