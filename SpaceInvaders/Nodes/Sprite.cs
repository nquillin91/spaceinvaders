using System.Diagnostics;

namespace SpaceInvaders.Nodes
{
    class Sprite : DLink
    {
        public Image pImage;
        public Azul.Sprite poAzulSprite;
        public Azul.Rect poRect = new Azul.Rect();
        public Name name;
        public float angle;
        public float scaleX;
        public float scaleY;
        public float x;
        public float y;

        public enum Name
        {
            RedBird,
            WhiteBird,
            GreenBird,
            YellowBird,
            Alien,
            AlienWhite,
            AlienSwap,
            Box,
            Stitch,
            Uninitialized
        }

        public Sprite(Name name) : base()
        {
            this.name = name;
        }

        public void Set(Name name, Image pImage, float x, float y, float width, float height)
        {
            this.name = name;
            this.pImage = pImage;
            this.x = x;
            this.y = y;
            this.angle = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;
            this.poRect.Set(x, y, width, height);
            this.poAzulSprite = new Azul.Sprite(this.pImage.pTexture.poAzulTexture, this.pImage.poRect, this.poRect);
        }

        public void SwapScreenRect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.poRect.Set(x, y, width, height);
            this.poAzulSprite.SwapScreenRect(this.poRect);
        }

        public void SwapImage(Image image)
        {
            Debug.Assert(image != null);

            this.pImage = image;
            this.poAzulSprite.SwapTexture(this.pImage.pTexture.poAzulTexture);
            this.poAzulSprite.SwapTextureRect(this.pImage.poRect);
        }

        public void SwapColor(float red, float green, float blue)
        {
            Azul.Color color = new Azul.Color(red, green, blue);
            Debug.Assert(color != null);

            this.poAzulSprite.SwapColor(color);
        }

        public void SwapColor(float red, float green, float blue, float alpha)
        {
            Azul.Color color = new Azul.Color(red, green, blue, alpha);
            Debug.Assert(color != null);

            this.poAzulSprite.SwapColor(color);
        }

        public void Update()
        {
            Debug.Assert(this.poAzulSprite != null);

            this.poRect.x = this.x;
            this.poRect.y = this.y;
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.scaleX;
            this.poAzulSprite.sy = this.scaleY;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }

        public void Render()
        {
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.Render();
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.poRect.Clear();
            this.pImage = null;
            if (poAzulSprite != null)
            {
                this.poAzulSprite.Dispose();
                this.poAzulSprite = null;
            }

            angle = 0.0f;
            scaleX = 1.0f;
            scaleY = 1.0f;
            x = 0.0f;
            y = 0.0f;
        }

        public override void DumpNode()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Image:" + (this.pImage == null ? "Null" : this.pImage.name.ToString()) +
                ", Sprite: " + (this.poAzulSprite == null ? "Null" : "Sprite Initialized") +
                ", Window Rect: " + (this.poRect == null ? "Null" : this.poRect.ToString()));
        }
    }
}
