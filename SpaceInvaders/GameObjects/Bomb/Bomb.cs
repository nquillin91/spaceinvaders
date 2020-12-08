
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        public float delta;
        private FallStrategy pStrategy;

        public Bomb(GameObject.Name name, GameSprite.Name spriteName, FallStrategy strategy, float posX, float posY)
            : base(name, spriteName, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 4.0f;

            Debug.Assert(strategy != null);
            this.pStrategy = strategy;

            this.pStrategy.Reset(this.y);

            this.poColObj.pColSprite.SetLineColor(1, 1, 0);
        }

        public void Reset()
        {
            this.y = 700.0f;
            this.pStrategy.Reset(this.y);
        }

        public override void Remove()
        {
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

        public override void Update()
        {
            base.Update();
            this.y -= delta;

            // Strategy
            this.pStrategy.Fall(this);
        }

        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }

        ~Bomb()
        {
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitBomb(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pProxySprite != null);

            this.pProxySprite.scaleX *= sx;
            this.pProxySprite.scaleY *= sy;
        }
    }
}
