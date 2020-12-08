
using SpaceInvaders.Batches;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        SpriteBatch pSpriteBatch;

        public AlienFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }

        ~AlienFactory()
        {

        }

        public GameObject Create(GameObject.Type type, float posX, float posY)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case GameObject.Type.Squid:
                    pGameObj = new Squid(GameObject.Name.Squid, GameSprite.Name.Squid, posX, posY);
                    break;

                case GameObject.Type.Crab:
                    pGameObj = new Crab(GameObject.Name.Crab, GameSprite.Name.Crab, posX, posY);
                    break;

                case GameObject.Type.Octopus:
                    pGameObj = new Octopus(GameObject.Name.Octopus, GameSprite.Name.Octopus, posX, posY);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            // Add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectManager.Attach(pGameObj);

            // Attached to Group
            this.pSpriteBatch.Attach(pGameObj.pProxySprite);

            return pGameObj;
        }
    }
}
