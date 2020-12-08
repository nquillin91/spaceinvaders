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
        protected Azul.Color prevColor = new Azul.Color(0.4f, 0.4f, 0.8f, 1.0f);
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        public enum Name
        {
            Squid,
            Crab,
            Octopus,

            AlienGrid,
            AlienColumn,

            Bomb,
            BombRoot,

            Missile,
            MissileGroup,

            Player,
            PlayerRoot,

            ShieldRoot,
            ShieldGrid,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,

            WallTop,
            WallBottom,
            WallGroup,

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

        public void SetCollisionColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.poColObj.pColSprite.SetLineColor(red, green, blue, alpha);
        }

        public void ToggleCollisions()
        {
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            Debug.Assert(this.prevColor != null);

            GameObject.psTmpColor.Set(this.poColObj.pColSprite.GetLineColor());

            this.poColObj.pColSprite.SetLineColor(this.prevColor);
            this.prevColor.Set(GameObject.psTmpColor);
        }

        ~GameObject()
        {

        }

        public virtual void Remove()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.pSprite.poScreenRect.Clear();
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
            pSpriteBatch.Attach(this.pProxySprite);
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
