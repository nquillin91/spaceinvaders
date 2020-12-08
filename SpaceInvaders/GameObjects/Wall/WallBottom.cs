using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallCategory
    {
        public WallBottom(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Bottom)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(1, 1, 0);
        }

        ~WallBottom()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallBottom(this);
        }

        public override void VisitBomb(Bomb b)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void VisitPlayerShip(PlayerShip b)
        {
        }

        public override void VisitMissile(Missile m)
        {
        }

        public override void VisitAlienGrid(AlienGrid a)
        {
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }
    }
}
