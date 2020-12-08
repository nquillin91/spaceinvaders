using SpaceInvaders.Images;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public class GameSprite : Sprite
    {
        protected Azul.Color poColor = new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f);

        private Name name;
        private Image pImage;
        public Azul.Sprite poAzulSprite;

        public enum Name
        {
            Octopus,
            Crab,
            Squid,

            Player,

            Missile,

            NullObject,
            Uninitialized
        }

        public GameSprite() : base() 
        {
            this.name = GameSprite.Name.Uninitialized;

            // Use the default - it will be replaced in the Set
            this.pImage = ImageManager.Find(Image.Name.Default);
            Debug.Assert(this.pImage != null);

            Debug.Assert(this.poScreenRect != null);
            this.poScreenRect.Clear();

            // here is the actual new
            Debug.Assert(this.poColor != null);

            // here is the actual new
            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poColor);
            Debug.Assert(this.poAzulSprite != null);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.scaleX = poAzulSprite.sx;
            this.scaleY = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public void Set(Name name, Image pImage, float x, float y, float width, float height, Azul.Color pColor)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(this.poScreenRect != null);
            Debug.Assert(this.poAzulSprite != null);

            this.poScreenRect.Set(x, y, width, height);
            this.pImage = pImage;
            this.name = name;

            if (pColor != null)
            {
                this.poColor.Set(pColor);
            }

            this.poAzulSprite.Swap(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poColor);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.scaleX = poAzulSprite.sx;
            this.scaleY = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        public void SetName(GameSprite.Name name)
        {
            this.name = name;
        }

        public GameSprite.Name GetName()
        {
            return this.name;
        }

        public override void SwapScreenRect(float x, float y, float width, float height)
        {
            base.SwapScreenRect(x, y, width, height);
            this.poAzulSprite.SwapScreenRect(this.poScreenRect);
        }

        public void SwapImage(Image image)
        {
            Debug.Assert(image != null);

            this.pImage = image;
            this.poAzulSprite.SwapTexture(this.pImage.pTexture.poAzulTexture);
            this.poAzulSprite.SwapTextureRect(this.pImage.poRect);
        }

        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            this.poColor.Set(red, green, blue, alpha);

            this.poAzulSprite.SwapColor(this.poColor);
        }

        public Azul.Rect GetScreenRect()
        {
            Debug.Assert(this.poScreenRect != null);
            return this.poScreenRect;
        }

        public override void Update()
        {
            base.Update();
            Debug.Assert(this.poAzulSprite != null);

            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.scaleX;
            this.poAzulSprite.sy = this.scaleY;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }

        public override void Render()
        {
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.Render();
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.pImage = null;
            if (poAzulSprite != null)
            {
                this.poAzulSprite.Dispose();
                this.poAzulSprite = null;
            }
        }

        public override void Dump()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Image:" + (this.pImage == null ? "Null" : this.pImage.GetName().ToString()) +
                ", Sprite: " + (this.poAzulSprite == null ? "Null" : "Sprite Initialized") +
                ", Window Rect: " + (this.poScreenRect == null ? "Null" : this.poScreenRect.ToString()));
        }
    }
}
