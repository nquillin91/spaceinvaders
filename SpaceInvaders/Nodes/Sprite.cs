using System;
using System.Diagnostics;

namespace SpaceInvaders.Nodes
{
    abstract class Sprite : DLink
    {
        public Azul.Rect poRect = new Azul.Rect();
        public Azul.Color poColor = new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f);
        public float angle;
        public float scaleX;
        public float scaleY;
        public float x;
        public float y;

        public Sprite() : base()
        {
        }

        public virtual void SwapScreenRect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.poRect.Set(x, y, width, height);
        }

        public virtual void SwapColor(float red, float green, float blue)
        {
            this.poColor.Set(red, green, blue);
            Debug.Assert(this.poColor != null);
        }

        public virtual void SwapColor(float red, float green, float blue, float alpha)
        {
            this.poColor.Set(red, green, blue, alpha);
            Debug.Assert(this.poColor != null);
        }

        public virtual void Update()
        {
            this.poRect.x = this.x;
            this.poRect.y = this.y;
        }

        public abstract void Render();

        public override void Wash()
        {
            base.Wash();

            this.poRect.Clear();

            angle = 0.0f;
            scaleX = 1.0f;
            scaleY = 1.0f;
            x = 0.0f;
            y = 0.0f;
        }

        public override abstract void Dump();
    }
}
