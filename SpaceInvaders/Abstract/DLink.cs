using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class DLink
    {
        public DLink pNext;
        public DLink pPrev;
        public int size;

        public DLink()
        {
            this.Wash();
        }

        public static void AddFirst(ref DLink pHead, ref DLink pTail, DLink pNode)
        {
            Debug.Assert(pNode != null);

            if (pHead == null)
            {
                pHead = pTail = pNode;
				pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                pNode.pPrev = null;
                pNode.pNext = pHead;
                pHead.pPrev = pNode;
                pHead = pNode;
            }
        }

        public static void AddLast(ref DLink pHead, ref DLink pTail, DLink pNode)
        {
            Debug.Assert(pNode != null);

            if (pTail == null)
            {
                pHead = pNode;
                pTail = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                pTail.pNext = pNode;
                pNode.pPrev = pTail;
                pNode.pNext = null;
                pTail = pNode;
            }

            Debug.Assert(pHead != null);
            Debug.Assert(pTail != null);
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

                    if (temp.pPrev != null)
                    {
                        temp.pPrev.pNext = pNode;
                    }
                    
                    temp.pPrev = pNode;
                    
                    if (temp == pHead)
                    {
                        pHead = pNode;
                    }

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

                    if (temp.pNext != null)
                    {
                        temp.pNext.pPrev = pNode;
                    }
                    
                    temp.pNext = pNode;

                    break;
                }

                temp = temp.pNext;
            }
        }

        public static DLink RemoveFromFront(ref DLink pHead, ref DLink pTail)
        {
            DLink headNode = pHead;

            if (headNode.pNext != null)
            {
                headNode.pNext.pPrev = null;
            }

            pHead = headNode.pNext;
            headNode.pNext = null;

            if (headNode.pNext == null && headNode.pPrev == null)
            {
                pTail = null;
            }

            return headNode;
        }

        public static void RemoveNode(ref DLink pHead, DLink pTargetNode)
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

        public static void RemoveNode(ref DLink pHead, ref DLink pTail, DLink pTargetNode)
        {
            Debug.Assert(pHead != null);
            Debug.Assert(pTail != null);
            Debug.Assert(pTargetNode != null);

            if (pTargetNode.pPrev != null)
            {
                pTargetNode.pPrev.pNext = pTargetNode.pNext;

                if (pTargetNode == pTail)
                {
                    pTail = pTargetNode.pPrev;
                }
            }
            else
            {
                pHead = pTargetNode.pNext;

                if (pTargetNode == pTail)
                {
                    pTail = pTargetNode.pNext;
                }
            }

            if (pTargetNode.pNext != null)
            {
                pTargetNode.pNext.pPrev = pTargetNode.pPrev;
            }

            pTargetNode.Wash();
        }

        public virtual void Wash()
        {
            this.pPrev = null;
            this.pNext = null;
            this.size = 0;
        }

        public abstract void Dump();

        public virtual void Destroy() {}
    }
}