using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Composites
{
    public abstract class Composite : GameObject
    {
        public DLink poHead;
        public DLink poTail;

        public Composite(GameObject.Name gameName, GameSprite.Name spriteName)
        : base(gameName, spriteName)
        {
            this.holder = Container.COMPOSITE;

            this.poHead = null;
            this.poTail = null;

            this.Dump();
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.AddLast(ref this.poHead, ref this.poTail, pComponent);
            pComponent.pParent = this;
        }

        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.RemoveNode(ref this.poHead, ref this.poTail, pComponent);
        }

        override public Component GetFirstChild()
        {
            DLink pNode = this.poHead;

            return (Component)pNode;
        }

        public override void Dump()
        {
            if (Iterator.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetHashCode(), Iterator.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetHashCode());
            }
        }
    }
}
