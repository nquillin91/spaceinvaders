using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public class BoxSprite : Sprite
    {
        static private Azul.Rect psTmpRect = new Azul.Rect();
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        private Name name;
        private readonly Azul.Color poLineColor;
        private Azul.SpriteBox poAzulBoxSprite;

        public enum Name
        {
            Box,
            Box1,
            Box2,
            Uninitialized
        }

        public BoxSprite() : base() 
        {
            this.name = BoxSprite.Name.Uninitialized;

            Debug.Assert(BoxSprite.psTmpRect != null);
            BoxSprite.psTmpRect.Set(0, 0, 1, 1);
            Debug.Assert(BoxSprite.psTmpColor != null);
            BoxSprite.psTmpColor.Set(1, 1, 1);

            // Here is the actual new
            this.poAzulBoxSprite = new Azul.SpriteBox(psTmpRect, psTmpColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            // Here is the actual new
            this.poLineColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poLineColor != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.scaleX = poAzulBoxSprite.sx;
            this.scaleY = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }

        public void Set(Name name, float x, float y, float width, float height, Azul.Color pLineColor = null)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poLineColor != null);

            Debug.Assert(psTmpRect != null);
            BoxSprite.psTmpRect.Set(x, y, width, height);

            this.name = name;

            if (pLineColor == null)
            {
                this.poLineColor.Set(1, 1, 1);
            }
            else
            {
                this.poLineColor.Set(pLineColor);
            }

            this.poAzulBoxSprite.Swap(psTmpRect, this.poLineColor);

            this.x     = poAzulBoxSprite.x;
            this.y     = poAzulBoxSprite.y;
            this.scaleX    = poAzulBoxSprite.sx;
            this.scaleY    = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }

        public void Set(BoxSprite.Name boxName, float x, float y, float width, float height)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poLineColor != null);
            Debug.Assert(psTmpRect != null);

            BoxSprite.psTmpRect.Set(x, y, width, height);

            this.name = boxName;

            this.poAzulBoxSprite.Swap(psTmpRect, this.poLineColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.scaleX = poAzulBoxSprite.sx;
            this.scaleY = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }

        public void SetName(BoxSprite.Name name)
        {
            this.name = name;
        }

        public BoxSprite.Name GetName()
        {
            return this.name;
        }

        public Azul.Color GetLineColor()
        {
            return this.poLineColor;
        }

        public override void SwapScreenRect(float x, float y, float width, float height)
        {
            base.SwapScreenRect(x, y, width, height);

            this.poAzulBoxSprite.SwapScreenRect(this.poScreenRect);
        }

        public void SetLineColor(Azul.Color pColor)
        {
            this.poLineColor.Set(pColor);
            this.poAzulBoxSprite.SwapColor(this.poLineColor);
        }

        public void SetLineColor(float red, float green, float blue, float alpha = 1.0f)
        {
            this.poLineColor.Set(red, green, blue, alpha);
            this.poAzulBoxSprite.SwapColor(this.poLineColor);
        }

        public void SetScreenRect(float x, float y, float width, float height)
        {
            this.Set(this.name, x, y, width, height);
        }

        public override void Update()
        {
            base.Update();

            Debug.Assert(this.poAzulBoxSprite != null);
            this.poAzulBoxSprite.x = this.x;
            this.poAzulBoxSprite.y = this.y;
            this.poAzulBoxSprite.sx = this.scaleX;
            this.poAzulBoxSprite.sy = this.scaleY;
            this.poAzulBoxSprite.angle = this.angle;
            this.poAzulBoxSprite.Update();
        }

        public override void Render()
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            this.poAzulBoxSprite.Render();
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;

            if (poAzulBoxSprite != null)
            {
                this.poAzulBoxSprite.Dispose();
                this.poAzulBoxSprite = null;
            }
        }

        public override void Dump()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Sprite: " + (this.poAzulBoxSprite == null ? "Null" : "Sprite Initialized") +
                ", Window Rect: " + (this.poScreenRect == null ? "Null" : this.poScreenRect.ToString()));
        }
    }
}
