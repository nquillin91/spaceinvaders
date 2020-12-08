using SpaceInvaders.Aliens;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sound;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class MoveAliensDownObserver : ColObserver
    {
        AlienGrid pAlienGrid = null;

        public MoveAliensDownObserver()
        {
            this.pAlienGrid = null;
        }

        public MoveAliensDownObserver(MoveAliensDownObserver m)
        {
            this.pAlienGrid = m.pAlienGrid;
        }

        public override void Notify()
        {
            bool isValidCollision = false;
            WallCategory pCurrentWallObject = (WallCategory)this.pSubject.pObjB;

            if ((pCurrentWallObject.GetCategoryType() == WallCategory.Type.Right &&
                AlienManager.GetPreviousWallCollisionType() != WallCategory.Type.Right) || 
                (pCurrentWallObject.GetCategoryType() == WallCategory.Type.Left &&
              AlienManager.GetPreviousWallCollisionType() != WallCategory.Type.Left))
            {
                isValidCollision = true;
            }

            if (isValidCollision)
            {
                this.pAlienGrid = (AlienGrid)this.pSubject.pObjA;
                Debug.Assert(this.pAlienGrid != null);

                MoveAliensDownObserver pObserver = new MoveAliensDownObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }

            AlienManager.SetPreviousWallCollisionType(pCurrentWallObject.GetCategoryType());
        }

        public override void Execute()
        {
            AlienManager.GetAlienGrid().SetVerticalState(AlienManager.State.MoveDown);
            AlienManager.ToggleCurrentDirection();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}