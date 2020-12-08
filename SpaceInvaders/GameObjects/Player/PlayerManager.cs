using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.States;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Player
{
    public class PlayerManager
    {
        private static PlayerManager pPlayerManagerInstance;
        private PlayerShip pShip;
        private Missile pMissile;

        private PlayerStateActive pStateActive;
        private PlayerStateNoAmmo pStateNoAmmo;
        //private readonly PlayerStateDead pStateDead;

        public enum State
        {
            Active,
            NoAmmo,
            Dead
        }

        private PlayerManager()
        {
            this.pStateActive = new PlayerStateActive();
            this.pStateNoAmmo = new PlayerStateNoAmmo();
            //this.pStateDead = new PlayerStateDead();

            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            Debug.Assert(pPlayerManagerInstance == null);

            if (pPlayerManagerInstance == null)
            {
                pPlayerManagerInstance = new PlayerManager();
            }

            Debug.Assert(pPlayerManagerInstance != null);

            pPlayerManagerInstance.pShip = ActivateShip();
            pPlayerManagerInstance.pShip.SetState(PlayerManager.State.Active);
        }

        private static PlayerManager GetInstance()
        {
            Debug.Assert(pPlayerManagerInstance != null);

            return pPlayerManagerInstance;
        }

        public static PlayerShip GetShip()
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }

        public static PlayerState GetState(State state)
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();
            Debug.Assert(pShipMan != null);

            PlayerState pShipState = null;

            switch (state)
            {
                case PlayerManager.State.Active:
                    pShipState = pShipMan.pStateActive;
                    break;

                case PlayerManager.State.NoAmmo:
                    pShipState = pShipMan.pStateNoAmmo;
                    break;

                /*case PlayerManager.State.Dead:
                    pShipState = pShipMan.pStateDead;
                    break;*/

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile GetMissile()
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();

            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }

        public static Missile ActivateMissile()
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();
            Debug.Assert(pShipMan != null);


            Missile pMissile = new Missile(GameObject.Name.Missile, GameSprite.Name.Missile, 9.0f * 50.0f, 225.0f);
            pMissile.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Aliens));
            pMissile.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            GameObject pMissileGroup = GameObjectManager.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject Tree - {update and collisions}
            pMissileGroup.Add(pMissile);
            pShipMan.pMissile = pMissile;

            return pShipMan.pMissile;
        }


        private static PlayerShip ActivateShip()
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();
            Debug.Assert(pShipMan != null);

            PlayerShip pShip = new PlayerShip(GameObject.Name.Player, GameSprite.Name.Player, 200, 100);
            pShipMan.pShip = pShip;

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchManager.Find(SpriteBatch.Name.Player);
            pSB_Aliens.Attach(pShip.pProxySprite);

            GameObject pShipRoot = GameObjectManager.Find(GameObject.Name.PlayerRoot);
            Debug.Assert(pShipRoot != null);

            pShipRoot.Add(pShipMan.pShip);

            return pShipMan.pShip;
        }
    }
}