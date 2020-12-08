using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Composites
{
    public abstract class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameObjectName, GameSprite.Name gameSpriteName) : base(gameObjectName, gameSpriteName)
        {
            this.holder = Container.LEAF;
        }

        override public void Add(Component c)
        {
            Debug.Assert(false);
        }

        override public void Remove(Component c)
        {
           Debug.Assert(false);
        }

        override public Component GetFirstChild()
        {
            Debug.Assert(false);
            return null;
        }

        override public void Dump()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1}) parent:{2}", this.GetName(), this.GetHashCode(), Iterator.GetParent(this).GetHashCode());
        }
    }
}
