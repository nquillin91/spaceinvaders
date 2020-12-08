using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public class Crab : AlienCategory
    {
        public Crab(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.points = 20;
        }

        ~Crab()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Call the appropriate collision reaction            
            other.VisitCrab(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Missile vs Bird
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