using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class SLink
    {
        public SLink pNext;
        public int size;

        public SLink()
        {
            this.Wash();
        }

        public static void AddFirst(ref SLink pHead, SLink pNode)
        {
            Debug.Assert(pNode != null);

            // If we don't have our head node set, let's set it now
            if (pHead == null)
            {
                pHead = pNode;
            }
            else
            {
                pNode.pNext = pHead;
                pHead = pNode;
            }
        }

        public virtual void Wash()
        {
            this.pNext = null;
            this.size = 0;
        }

        public abstract void Dump();

        public virtual void Destroy() {}
    }
}