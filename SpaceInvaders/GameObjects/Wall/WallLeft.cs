using SpaceInvaders.Aliens;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallLeft : WallCategory
    {
        public WallLeft(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Left)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(0, 0, 0);
        }

        ~WallLeft()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallLeft(this);
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void VisitBomb(Bomb b)
        {
        }

        public override void VisitPlayerShip(PlayerShip b)
        {
            PlayerManager.GetShip().SetPlayerState(PlayerManager.State.NoMoveLeft);
        }

        public override void VisitAlienGrid(AlienGrid a)
        {
            Debug.WriteLine("\ncollide: {0} with {1}", this, a);
            Debug.WriteLine("\nWall X: {0} Y: {1}", this.x, this.y);
            Debug.WriteLine("\nGrid X: {0} Y: {1}", a.x, a.y);
            Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairManager.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }
    }
}
