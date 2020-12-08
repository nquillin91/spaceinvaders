using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.States;
using SpaceInvaders.States.Alien;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Aliens
{
    public class AlienManager
    {
        private static AlienManager poAlienManagerInstance;

        public WallCategory.Type prevWallCollisionType = WallCategory.Type.Unitialized;
        private AlienGrid poAlienGrid;

        private AlienGridStateNoMoveDown poAlienGridStateNoMoveDown;
        private AlienGridStateMoveDown poAlienGridStateMoveDown;

        private AlienGridStateNoMoveHorizontally poAlienGridStateNoMoveHorizontally;
        private AlienGridStateMoveHorizontally poAlienGridStateMoveHorizontally;

        private bool isUFOInPlay = false;

        private float startSpeed = 5.0f;
        private float currentSpeed = 5.0f;
        private float currentDirection = -1.0f;
        private float speedChangeDelta = 2.0f;
        private float ufoDirection = 1.0f;
        private float ufoSpeed = 2.5f;
        private float marchingSpeedChange = 2.5f;

        public enum State
        {
            NoMoveDown,
            MoveDown
        }

        public enum HorizontalState
        {
            NoMoveHorizontally,
            MoveHorizontally
        }

        private AlienManager()
        {
            // Setup grid states
            this.poAlienGridStateNoMoveDown = new AlienGridStateNoMoveDown();
            this.poAlienGridStateMoveDown = new AlienGridStateMoveDown();

            // Setup horizontal grid states
            this.poAlienGridStateNoMoveHorizontally = new AlienGridStateNoMoveHorizontally();
            this.poAlienGridStateMoveHorizontally = new AlienGridStateMoveHorizontally();

            this.poAlienGrid = null;
        }

        public static void Create(float startSpeedFactor = 1.0f)
        {
            if (poAlienManagerInstance == null)
            {
                poAlienManagerInstance = new AlienManager();
            }

            Debug.Assert(poAlienManagerInstance != null);

            poAlienManagerInstance.currentSpeed = poAlienManagerInstance.startSpeed * startSpeedFactor;
            poAlienManagerInstance.isUFOInPlay = false;

            poAlienManagerInstance.poAlienGrid = ActivateGrid();
            poAlienManagerInstance.poAlienGrid.SetVerticalState(AlienManager.State.NoMoveDown);
            poAlienManagerInstance.poAlienGrid.SetHorizontalState(AlienManager.HorizontalState.NoMoveHorizontally);
        }

        private static AlienManager GetInstance()
        {
            Debug.Assert(poAlienManagerInstance != null);

            return poAlienManagerInstance;
        }

        public static WallCategory.Type GetPreviousWallCollisionType()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);

            return pAlienMan.prevWallCollisionType;
        }

        public static void SetPreviousWallCollisionType(WallCategory.Type type)
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);
            pAlienMan.prevWallCollisionType = type;
        }

        public static AlienGrid GetAlienGrid()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);
            Debug.Assert(pAlienMan.poAlienGrid != null);

            return pAlienMan.poAlienGrid;
        }

        public static bool IsUFOInPlay()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            return pAlienMan.isUFOInPlay;
        }

        public static void SetIsUFOInPlay(bool isUFOInPlay)
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            pAlienMan.isUFOInPlay = isUFOInPlay;

            if (isUFOInPlay)
            {
                SoundManager.Find(AudioSource.Name.UFOBeep).Play();
            } else
            {
                SoundManager.Find(AudioSource.Name.UFOBeep).Stop();
            }
        }

        public static float GetUFODirection()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            return pAlienMan.ufoDirection;
        }

        public static float GetUFOSpeed()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            return pAlienMan.ufoSpeed;
        }

        public static void ToggleUFODirection()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            pAlienMan.ufoDirection *= -1.0f;
        }

        public static float GetCurrentSpeed()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);

            return pAlienMan.currentSpeed;
        }

        public static float GetCurrentDirection()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);

            return pAlienMan.currentDirection;
        }

        public static void ToggleCurrentDirection()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();

            Debug.Assert(pAlienMan != null);
            pAlienMan.currentDirection *= -1.0f;
        }

        public static void UpdateSpeed()
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            pAlienMan.currentSpeed += pAlienMan.speedChangeDelta;
            pAlienMan.poAlienGrid.marchIterationSetSpeed -= pAlienMan.marchingSpeedChange;
        }

        public static AlienGridVerticalState GetState(State state)
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            AlienGridVerticalState pGridState = null;

            switch (state)
            {
                case AlienManager.State.NoMoveDown:
                    pGridState = pAlienMan.poAlienGridStateNoMoveDown;
                    break;

                case AlienManager.State.MoveDown:
                    pGridState = pAlienMan.poAlienGridStateMoveDown;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pGridState;
        }

        public static AlienGridHorizontalState GetHorizontalState(HorizontalState state)
        {
            AlienManager pAlienMan = AlienManager.GetInstance();
            Debug.Assert(pAlienMan != null);

            AlienGridHorizontalState pGridState = null;

            switch (state)
            {
                case AlienManager.HorizontalState.NoMoveHorizontally:
                    pGridState = pAlienMan.poAlienGridStateNoMoveHorizontally;
                    break;

                case AlienManager.HorizontalState.MoveHorizontally:
                    pGridState = pAlienMan.poAlienGridStateMoveHorizontally;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pGridState;
        }

        private static AlienGrid ActivateGrid()
        {
            AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
            return (AlienGrid)alienFactory.Create(GameObject.Name.AlienGrid, AlienCategory.Type.Grid);
        }
    }
}