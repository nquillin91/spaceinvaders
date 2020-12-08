using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public abstract class GameObject : Component
    {
        public uint instanceId = 0u;
        public GameObject.Name name;

        public float x;
        public float y;
        public ProxySprite pProxySprite;
        protected ColObject poColObj;
        public SpriteBatch pAssociatedSpriteBatch;

        public enum Name
        {
            Squid,
            Crab,
            Octopus,

            AlienGrid,
            AlienColumn,

            Missile,
            MissileGroup,

            Player,
            PlayerRoot,

            NullObject,
            Uninitialized
        }

        protected GameObject() { }

        protected GameObject(GameObject.Name gameName) : base()
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = null;
        }

        protected GameObject(GameObject.Name gameName, GameSprite.Name spriteName) : base()
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pProxySprite = ProxySpriteManager.Add(spriteName);

            this.poColObj = new ColObject(this.pProxySprite);
            Debug.Assert(this.poColObj != null);
        }

        public GameObject.Name GetName()
        {
            return this.name;
        }

        public ColObject GetColObject()
        {
            Debug.Assert(this.poColObj != null);
            return this.poColObj;
        }

        ~GameObject()
        {

        }

        public virtual void Remove()
        {
            Debug.Assert(this.pProxySprite != null);
            SpriteNode pSpriteNode = this.pProxySprite.GetSpriteNode();

            // Remove it from the manager
            Debug.Assert(pSpriteNode != null);
            SpriteBatchManager.Remove(pSpriteNode);

            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            pSpriteNode = this.poColObj.pColSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteBatchManager.Remove(pSpriteNode);
            GameObjectManager.Remove(this);
        }

        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;

            Debug.Assert(this.poColObj != null);
            this.poColObj.UpdatePosition(this.x, this.y);

            Debug.Assert(this.poColObj.pColSprite != null);
            this.poColObj.pColSprite.Update();
        }

        public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poColObj != null);
            pSpriteBatch.Attach(this.poColObj.pColSprite);
        }

        public void ActivateGameSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            this.pAssociatedSpriteBatch = pSpriteBatch;
            this.pAssociatedSpriteBatch.Attach(this.pProxySprite);
        }

        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;
            ColRect ColTotal = this.poColObj.poColRect;

            // Get the first child
            pNode = (GameObject)Iterator.GetChild(pNode);

            if (pNode != null)
            {
                // Initialized the union to the first block
                ColTotal.Set(pNode.poColObj.poColRect);

                // loop through sliblings
                while (pNode != null)
                {
                    ColTotal.Union(pNode.poColObj.poColRect);

                    pNode = (GameObject)Iterator.GetSibling(pNode);
                }

                this.x = this.poColObj.poColRect.x;
                this.y = this.poColObj.poColRect.y;
            }
        }
    }
}
