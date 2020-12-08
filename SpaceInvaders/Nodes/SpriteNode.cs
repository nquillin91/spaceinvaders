using SpaceInvaders.Nodes.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Nodes
{
    class SpriteNode : DLink
    {
        public Sprite pSprite;

        public SpriteNode() : base()
        {
            this.pSprite = null;
        }

        public void Set(GameSprite.Name name)
        {
            this.pSprite = GameSpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public void Set(BoxSprite.Name name)
        {
            this.pSprite = BoxSpriteManager.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public override void Wash()
        {
            base.Wash();

            this.pSprite = null;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}