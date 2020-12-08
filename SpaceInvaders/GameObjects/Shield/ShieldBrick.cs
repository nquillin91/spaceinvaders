﻿using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Shield
{
    public class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~ShieldBrick()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldBrick(this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb vs ShieldBrick
            //Debug.WriteLine(" ---> Done");
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
