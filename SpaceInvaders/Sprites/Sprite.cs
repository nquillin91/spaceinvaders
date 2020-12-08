using SpaceInvaders.Batches;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public abstract class Sprite : DLink
    {
        // This is used to maintain a reference for deletion
        private SpriteNode pBackSpriteNode;

        public Azul.Rect poScreenRect = new Azul.Rect();
        public float angle;
        public float scaleX;
        public float scaleY;
        public float x;
        public float y;

        public Sprite() : base()
        {
            this.pBackSpriteNode = null;

            this.x = 0.0f;
            this.y = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;
            this.angle = 0.0f;
        }

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.pBackSpriteNode != null);
            return this.pBackSpriteNode;
        }

        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSpriteNode = pSpriteBatchNode;
        }

        public virtual void SwapScreenRect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.poScreenRect.Set(x, y, width, height);
        }

        public virtual void Update()
        {
            this.poScreenRect.x = this.x;
            this.poScreenRect.y = this.y;
        }

        public abstract void Render();

        public override void Wash()
        {
            base.Wash();

            this.poScreenRect.Clear();

            angle = 0.0f;
            scaleX = 1.0f;
            scaleY = 1.0f;
            x = 0.0f;
            y = 0.0f;
        }

        public override abstract void Dump();
    }
}
