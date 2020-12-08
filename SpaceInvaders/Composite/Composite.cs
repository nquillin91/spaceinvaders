﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Composite : Component
    {
        public DLink poHead;

        public Composite()
        {
            this.poHead = null;
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.AddFirst(ref this.poHead, pComponent);
        }

        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.RemoveNode(ref this.poHead, pComponent);
        }
        public override void Move()
        {
            DLink pNode = this.poHead;

            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Move();

                pNode = pNode.pNext;
            }
        }
        public override void Print()
        {
            DLink pNode = this.poHead;

            while(pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Print();

                pNode = pNode.pNext;
            }

        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
