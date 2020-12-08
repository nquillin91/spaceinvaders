using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public class UFO : AlienCategory
    {
        private static Random poRandom = new Random();

        public UFO(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.points = poRandom.Next(50, 101);
        }

        ~UFO()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Call the appropriate collision reaction            
            other.VisitUFO(this);
        }

        public override void VisitWallRight(WallRight w)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(w, this);
            pColPair.NotifyListeners();
        }

        public override void VisitWallLeft(WallLeft w)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(w, this);
            pColPair.NotifyListeners();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }
    }
}