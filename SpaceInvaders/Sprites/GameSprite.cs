using SpaceInvaders.Images;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public class GameSprite : Sprite
    {
        private Name name;
        public Image pImage;
        public Azul.Sprite poAzulSprite;

        public enum Name
        {
            Octopus,
            Crab,
            Squid,
            Uninitialized
        }

        public GameSprite() : base() {}

        public void Set(Name name, Image pImage, float x, float y, float width, float height)
        {
            this.name = name;
            this.pImage = pImage;
            this.x = x;
            this.y = y;
            this.poRect.Set(x, y, width, height);
            this.poAzulSprite = new Azul.Sprite(this.pImage.pTexture.poAzulTexture, this.pImage.poRect, this.poRect);
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
            this.poAzulSprite.SwapScreenRect(this.poRect);
        }

        public void SwapImage(Image image)
        {
            Debug.Assert(image != null);

            this.pImage = image;
            this.poAzulSprite.SwapTexture(this.pImage.pTexture.poAzulTexture);
            this.poAzulSprite.SwapTextureRect(this.pImage.poRect);
        }

        public override void SwapColor(float red, float green, float blue)
        {
            base.SwapColor(red, green, blue);
            Debug.Assert(this.poColor != null);

            this.poAzulSprite.SwapColor(this.poColor);
        }

        public override void SwapColor(float red, float green, float blue, float alpha)
        {
            base.SwapColor(red, green, blue, alpha);
            Debug.Assert(this.poColor != null);

            this.poAzulSprite.SwapColor(this.poColor);
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
                ", Window Rect: " + (this.poRect == null ? "Null" : this.poRect.ToString()));
        }
    }
}
