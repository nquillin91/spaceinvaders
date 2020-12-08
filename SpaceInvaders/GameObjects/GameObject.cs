using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Leaf
    {
        public GameObject.Name name;

        public float x;
        public float y;
        public ProxySprite pProxySprite;

        public enum Type
        {
            Squid,
            Crab,
            Octopus
        }

        public enum Name
        {
            Squid,
            Crab,
            Octopus,

            Null_Object,
            Uninitialized
        }

        protected GameObject(GameObject.Name gameName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = null;
        }

        protected GameObject(GameObject.Name gameName, GameSprite.Name spriteName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = new ProxySprite(spriteName);
        }

        public override GameObject.Name GetName()
        {
            return this.name;
        }

        ~GameObject()
        {

        }

        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;
        }
    }
}
