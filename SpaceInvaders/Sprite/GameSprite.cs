using SpaceInvaders.Images;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public class GameSprite : SpriteBase
    {
        protected Azul.Color poColor = new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f);

        public float x;
        public float y;
        public float scaleX;
        public float scaleY;
        public float angle;

        private Name name;
        private Image pImage;
        private readonly Azul.Color poAzulColor;
        private readonly Azul.Sprite poAzulSprite;
        private readonly Azul.Rect poScreenRect;

        static readonly private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        public enum Name
        {
            Octopus,
            Crab,
            Squid,
            DeadAlien,

            UFO,
            DeadUFO,

            Player,
            DeadPlayer1,
            DeadPlayer2,

            Missile,
            DeadMissile,

            Wall,

            BombStraight,
            BombZigZag,
            BombDagger,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            NullObject,
            Uninitialized
        }

        public GameSprite() : base() 
        {
            this.name = GameSprite.Name.Uninitialized;

            // Use the default - it will be replaced in the Set
            this.pImage = ImageManager.Find(Image.Name.Default);
            Debug.Assert(this.pImage != null);

            this.poScreenRect = new Azul.Rect();
            Debug.Assert(this.poScreenRect != null);
            this.poScreenRect.Clear();

            // here is the actual new
            this.poAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poAzulColor != null);

            // here is the actual new
            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, psTmpColor);
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

            if (pColor == null)
            {
                Debug.Assert(GameSprite.psTmpColor != null);
                GameSprite.psTmpColor.Set(1, 1, 1);

                this.poAzulColor.Set(psTmpColor);
            }
            else
            {
                this.poAzulColor.Set(pColor);
            }

            this.poAzulSprite.Swap(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poAzulColor);

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

        public void SwapImage(Image image)
        {
            Debug.Assert(image != null);

            this.pImage = image;
            this.poAzulSprite.SwapTexture(this.pImage.pTexture.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImage.poRect);
        }

        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poAzulColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulColor.Set(red, green, blue, alpha);
            this.poAzulSprite.SwapColor(this.poAzulColor);
        }

        public Azul.Rect GetScreenRect()
        {
            Debug.Assert(this.poScreenRect != null);
            return this.poScreenRect;
        }

        public override void Update()
        {
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

            this.pImage = null;
            this.name = GameSprite.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;
            this.angle = 0.0f;
        }

        public override void Dump()
        {
            // Dump - Print contents to the debug output window
            //        Using HASH code as its unique identifier 
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("             Image: {0} ({1})", this.pImage.GetName(), this.pImage.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.scaleX, this.scaleY);
            Debug.WriteLine("           (angle): {0}", this.angle);


            if (this.pNext == null)
            {
                Debug.WriteLine("              next: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pNext;
                Debug.WriteLine("              next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("              prev: null");
            }
            else
            {
                GameSprite pTmp = (GameSprite)this.pPrev;
                Debug.WriteLine("              prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }
    }
}
