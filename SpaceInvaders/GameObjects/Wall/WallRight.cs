﻿using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallRight: WallCategory
    {
        public WallRight(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Right)
        {
            this.poColObj.poColRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(1, 1, 0);
        }

        ~WallRight()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitWallRight(this);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void VisitAlienGrid(AlienGrid a)
        {
            Debug.WriteLine("\ncollide: {0} with {1}", this, a);
            Debug.WriteLine("               --->DONE<----");

            ColPair pColPair = ColPairManager.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.SetCollision(a, this);
            pColPair.NotifyListeners();
        }
    }
}
