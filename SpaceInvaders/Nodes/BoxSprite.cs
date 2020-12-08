using System;
using System.Diagnostics;

namespace SpaceInvaders.Nodes.Sprites
{
    class BoxSprite : Sprite
    {
        public Name name;
        public Azul.SpriteBox poAzulSpriteBox;

        public enum Name
        {
            Box1,
            Box2,
            Uninitialized
        }

        public BoxSprite() : base() 
        {
            this.angle = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;
        }

        public void Set(Name name, float x, float y, float width, float height, Azul.Color poColor = null)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.poRect.Set(x, y, width, height);

            if (poColor != null)
            {
                this.poColor.Set(poColor);
            }
            
            this.poAzulSpriteBox = new Azul.SpriteBox(this.poRect, this.poColor);
        }

        public override void SwapScreenRect(float x, float y, float width, float height)
        {
            base.SwapScreenRect(x, y, width, height);

            this.poAzulSpriteBox.SwapScreenRect(this.poRect);
        }

        public override void SwapColor(float red, float green, float blue)
        {
            base.SwapColor(red, green, blue);

            this.poAzulSpriteBox.SwapColor(this.poColor);
        }

        public override void SwapColor(float red, float green, float blue, float alpha)
        {
            base.SwapColor(red, green, blue, alpha);

            this.poAzulSpriteBox.SwapColor(this.poColor);
        }

        public override void Update()
        {
            base.Update();

            Debug.Assert(this.poAzulSpriteBox != null);
            this.poAzulSpriteBox.x = this.x;
            this.poAzulSpriteBox.y = this.y;
            this.poAzulSpriteBox.sx = this.scaleX;
            this.poAzulSpriteBox.sy = this.scaleY;
            this.poAzulSpriteBox.angle = this.angle;
            this.poAzulSpriteBox.Update();
        }

        public override void Render()
        {
            Debug.Assert(this.poAzulSpriteBox != null);
            this.poAzulSpriteBox.Render();
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;

            if (poAzulSpriteBox != null)
            {
                this.poAzulSpriteBox.Dispose();
                this.poAzulSpriteBox = null;
            }
        }

        public override void Dump()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Sprite: " + (this.poAzulSpriteBox == null ? "Null" : "Sprite Initialized") +
                ", Window Rect: " + (this.poRect == null ? "Null" : this.poRect.ToString()));
        }
    }
}
