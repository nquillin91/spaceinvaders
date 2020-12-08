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
        private static PlayerNumber playerNum;
        private PlayerShip pShip;
        private Missile pMissile;

        // Player states
        private PlayerStateFreeMove pStateFreeMove;
        private PlayerStateNoMoveLeft pStateNoMoveLeft;
        private PlayerStateNoMoveRight pStateNoMoveRight;
        private readonly PlayerStateDead pStateDead;

        // Missile States
        private PlayerMissileStateReady pMissileStateReady;
        private PlayerMissileStateNoAmmo pMissileStateNoAmmo;

        public enum PlayerNumber
        {
            Player1,
            Player2
        }

        public enum State
        {
            FreeMove,
            NoMoveLeft,
            NoMoveRight,
            Dead
        }

        public enum MissileState
        {
            Ready,
            NoAmmo
        }

        private PlayerManager()
        {
            // Setup player states
            this.pStateFreeMove = new PlayerStateFreeMove();
            this.pStateNoMoveLeft = new PlayerStateNoMoveLeft();
            this.pStateNoMoveRight = new PlayerStateNoMoveRight();
            this.pStateDead = new PlayerStateDead();

            // Setup player missile states
            this.pMissileStateReady = new PlayerMissileStateReady();
            this.pMissileStateNoAmmo = new PlayerMissileStateNoAmmo();

            this.pShip = null;
            this.pMissile = null;
        }

        public static void Create()
        {
            if (pPlayerManagerInstance == null)
            {
                pPlayerManagerInstance = new PlayerManager();
            }

            Debug.Assert(pPlayerManagerInstance != null);

            pPlayerManagerInstance.pShip = ActivateShip();
            pPlayerManagerInstance.pShip.SetPlayerState(PlayerManager.State.FreeMove);
            pPlayerManagerInstance.pShip.SetMissileState(PlayerManager.MissileState.Ready);
        }

        private static PlayerManager GetInstance()
        {
            Debug.Assert(pPlayerManagerInstance != null);

            return pPlayerManagerInstance;
        }

        public static PlayerNumber GetPlayerNumber()
        {
            return playerNum;
        }

        public static void SetPlayerNumber(PlayerNumber number)
        {
            playerNum = number;
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
                case PlayerManager.State.FreeMove:
                    pShipState = pShipMan.pStateFreeMove;
                    break;

                case PlayerManager.State.NoMoveLeft:
                    pShipState = pShipMan.pStateNoMoveLeft;
                    break;

                case PlayerManager.State.NoMoveRight:
                    pShipState = pShipMan.pStateNoMoveRight;
                    break;

                case PlayerManager.State.Dead:
                    pShipState = pShipMan.pStateDead;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static PlayerMissileState GetMissileState(MissileState state)
        {
            PlayerManager pShipMan = PlayerManager.GetInstance();
            Debug.Assert(pShipMan != null);

            PlayerMissileState pShipState = null;

            switch (state)
            {
                case PlayerManager.MissileState.Ready:
                    pShipState = pShipMan.pMissileStateReady;
                    break;

                case PlayerManager.MissileState.NoAmmo:
                    pShipState = pShipMan.pMissileStateNoAmmo;
                    break;

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