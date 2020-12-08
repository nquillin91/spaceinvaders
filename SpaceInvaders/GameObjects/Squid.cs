using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Squid : GameObject
    {
        public Squid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        // Data: ---------------
        ~Squid()
        {

        }

        public override void Move()
        {
            this.x += delta;
            if (this.x >= 800.0f)
            {
                delta *= -1;
            }
            else if (this.x <= 0)
            {
                delta *= -1;
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}