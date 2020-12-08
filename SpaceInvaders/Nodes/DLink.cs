using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class DLink
    {
        public DLink pNext;
        public DLink pPrev;

        public DLink()
        {
            this.Wash();
        }

        public virtual void Wash() {
            pNext = null;
            pNext = null;
        }

        public static void AddFirst(ref DLink pHead, ref DLink pTail, ref DLink pNode)
        {
            Debug.Assert(pNode != null);

            // If we don't have our head node set, let's set it now
            if (pHead == null)
            {
                pHead = pTail = pNode;
            }
            else
            {
                pNode.pPrev = null;
                pNode.pNext = pHead;
                pHead.pPrev = pNode;
                pHead = pNode;
            }
        }

        public static void AddLast(ref DLink pTail, ref DLink pNode)
        {
            Debug.Assert(pNode != null);
            Debug.Assert(pTail != null);

            pNode.pPrev = pTail;
            pTail.pNext = pNode;
            pTail = pNode;
        }

        public static void InsertBeforeNode(ref DLink pHead, ref DLink pTargetNode, ref DLink pNode)
        {
            Debug.Assert(pHead != null);
            Debug.Assert(pTargetNode != null);
            Debug.Assert(pNode != null);

            DLink temp = pHead;

            while (temp != null)
            {
                if (temp == pTargetNode)
                {
                    pNode.pPrev = temp.pPrev;
                    pNode.pNext = temp;
                    temp.pPrev.pNext = pNode;
                    temp.pPrev = pNode;

                    break;
                }

                temp = temp.pNext;
            }
        }

        public static void InsertAfterNode(ref DLink pHead, ref DLink pTargetNode, ref DLink pNode)
        {
            Debug.Assert(pHead != null);
            Debug.Assert(pTargetNode != null);
            Debug.Assert(pNode != null);

            DLink temp = pHead;

            while (temp != null)
            {
                if (temp == pTargetNode)
                {
                    pNode.pPrev = temp;
                    pNode.pNext = temp.pNext;
                    temp.pNext.pPrev = pNode;
                    temp.pNext = pNode;

                    pTargetNode.pNext = null;
                    pTargetNode.pPrev = null;

                    break;
                }

                temp = temp.pNext;
            }
        }

        public static void RemoveNode(ref DLink pHead, ref DLink pTargetNode)
        {
            Debug.Assert(pHead != null);
            Debug.Assert(pTargetNode != null);

            DLink temp = pHead;

            while (temp != null)
            {
                if (temp == pTargetNode)
                {
                    temp.pPrev.pNext = temp.pNext;

                    if (temp.pNext != null)
                    {
                        temp.pNext.pPrev = temp.pPrev;
                    }

                    temp.pPrev = temp.pNext;

                    pTargetNode.pNext = null;
                    pTargetNode.pPrev = null;

                    break;
                }

                temp = temp.pNext;
            }
        }

        public static DLink RemoveFromFront(ref DLink pHead)
        {
            DLink headNode = pHead;

            if (headNode.pNext != null)
            {
                headNode.pNext.pPrev = null;
            }

            pHead = headNode.pNext;
            headNode.pNext = null;

            return headNode;
        }

        public abstract void DumpNode();
    }
}