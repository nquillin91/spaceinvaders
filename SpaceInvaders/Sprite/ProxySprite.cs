using System;
using System.Diagnostics;

namespace SpaceInvaders.Sprites
{
    public class ProxySprite : SpriteBase
    {
        public ProxySprite.Name name;
        public float x;
        public float y;
        public float scaleX;
        public float scaleY;
        public GameSprite pSprite;

        public enum Name
        {
            Proxy,
            Uninitialized
        }

        public ProxySprite()
            : base()
        {
            this.name = Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = null;
        }

        public ProxySprite(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;

            this.pSprite = GameSpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        ~ProxySprite()
        {

        }

        public void Set(GameSprite.Name name)
        {
            this.name = Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;

            this.pSprite = GameSpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public void SetName(Name inName)
        {
            this.name = inName;
        }
        public Name GetName()
        {
            return this.name;
        }

        public override void Update()
        {
            Debug.Assert(this.pSprite != null);

            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
            this.pSprite.scaleX = this.scaleX;
            this.pSprite.scaleY = this.scaleY;

            this.pSprite.Update();
        }

        public override void Wash()
        {
            base.Wash();

            this.x = 0.0f;
            this.y = 0.0f;
            this.scaleX = 1.0f;
            this.scaleY = 1.0f;
            this.name = Name.Uninitialized;

            this.pSprite = null;
        }

        public override void Render()
        {
            this.Update();
            this.pSprite.Render();
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
