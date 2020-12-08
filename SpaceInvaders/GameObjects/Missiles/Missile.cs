using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public class Missile : AlienCategory
    {
        public float delta = 3.0f;

        public Missile(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(255, 0, 0);
        }

        public override void Update()
        {
            base.Update();

            this.y += delta;
        }

        ~Missile()
        {

        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction            
            other.VisitMissile(this);
        }

        public void SetPosition(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
    }
}