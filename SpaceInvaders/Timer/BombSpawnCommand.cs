using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombSpawnCommand : Command
    {
        GameObject pBombRoot;
        SpriteBatch pSB_Birds;
        SpriteBatch pSB_Boxes;
        Random pRandom;

        public BombSpawnCommand(Random pRandom)
        {
            this.pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Birds = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            Debug.Assert(this.pSB_Birds != null);

            this.pSB_Boxes = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            float value = pRandom.Next(300, 700);
            Bomb pBomb = new Bomb(GameObject.Name.Bomb, GameSprite.Name.BombStraight, new FallStraight(), value, 600.0f);

            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateGameSprite(this.pSB_Birds);

            // Attach the missile to the Bomb root
            GameObject pBombRoot = GameObjectManager.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);
            pBombRoot.Add(pBomb);
        }
    }
}