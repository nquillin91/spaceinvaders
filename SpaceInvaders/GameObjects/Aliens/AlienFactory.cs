
using SpaceInvaders.Batches;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    class AlienFactory
    {
        private readonly SpriteBatch pBoxSpriteBatch;
        private readonly SpriteBatch pSpriteBatch;

        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchManager.Find(boxSpriteBatchName);
            Debug.Assert(this.pBoxSpriteBatch != null);
        }

        ~AlienFactory()
        {
        }

        public GameObject Create(GameObject.Name name, AlienCategory.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.Squid:
                    pGameObj = new Squid(name, GameSprite.Name.Squid, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    pGameObj = new Crab(name, GameSprite.Name.Crab, posX, posY);
                    break;

                case AlienCategory.Type.Octopus:
                    pGameObj = new Octopus(name, GameSprite.Name.Octopus, posX, posY);
                    break;

                case AlienCategory.Type.Grid:
                    pGameObj = new AlienGrid(name, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                case AlienCategory.Type.Column:
                    pGameObj = new AlienColumn(name, GameSprite.Name.NullObject, 0.0f, 0.0f);

                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            // Add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            //GameObjectManager.Attach(pGameObj);

            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxSpriteBatch);

            return pGameObj;
        }
    }
}
