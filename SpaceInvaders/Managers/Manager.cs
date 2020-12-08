using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Manager
    {
        protected DLink poActive;
        protected DLink poActiveTail;
        protected DLink poReserve;
        protected DLink poReserveTail;

        protected int growthSize = 0;
        protected int reserveSize = 0;
        protected int reserveNum = 0;
        protected int activeNum = 0;

        protected Manager(int reserveSize, int growthSize)
        {
            Debug.Assert(growthSize > 0);
            Debug.Assert(reserveSize >= 0);

            this.growthSize = growthSize;
            this.reserveSize = reserveSize;

            this.GenerateReserveNodes(reserveSize);
        }

        protected void GenerateReserveNodes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                DLink pNewNode = this.CreateNode();
                
                if (poReserve == null)
                {
                    poReserve = poReserveTail = pNewNode;
                } else
                {
                    DLink.AddFirst(ref poReserve, ref poReserveTail, ref pNewNode);
                }

                reserveNum++;
            }
        }

        protected DLink BaseAddNode()
        {
            if (reserveNum == 0)
            {
                this.GenerateReserveNodes(this.growthSize);
            }

            DLink pLink = DLink.RemoveFromFront(ref poReserve);

            Debug.Assert(pLink != null);
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);

            DLink.AddFirst(ref poActive, ref poActiveTail, ref pLink);

            activeNum++;
            reserveNum--;

            return pLink;
        }

        protected void BaseRemove(DLink pNode)
        {
            if (this.CompareNodes(poActive, pNode))
            {
                DLink.RemoveFromFront(ref poActive);
            } else
            {
                DLink.RemoveNode(ref poActive, ref pNode);
            }

            pNode.Wash();

            DLink.AddFirst(ref poReserve, ref poReserveTail, ref pNode);

            activeNum--;
            reserveNum++;
        }

        protected DLink BaseFind(DLink pTargetNode)
        {
            DLink temp = poActive;

            while (temp != null)
            {
                
                if (CompareNodes(temp, pTargetNode))
                {
                    return temp;
                }

                temp = temp.pNext;
            }

            return temp;
        }

        protected abstract DLink CreateNode();
        protected abstract Boolean CompareNodes(DLink pLinkA, DLink pLinkB);

        public void PrintStats()
        {
            System.Diagnostics.Debug.WriteLine("------------- STATS --------------");
            System.Diagnostics.Debug.WriteLine("Initial Reserve Size = " + this.reserveSize + ", ");
            System.Diagnostics.Debug.WriteLine("Growth Size = " + this.growthSize);
            System.Diagnostics.Debug.WriteLine("Total Number in Active and Reserve = " + (this.reserveNum + this.activeNum));
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            System.Diagnostics.Debug.WriteLine("Number in Reserve = " + this.reserveNum);
            if (poReserve != null)
            {
                DLink temp = poReserve;

                while (temp != null)
                {
                    temp.DumpNode();

                    temp = temp.pNext;
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("No Reserve Node Detail Available");
            }
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            System.Diagnostics.Debug.WriteLine("Number in Active = " + this.activeNum);
            if (poActive != null)
            {
                DLink temp = poActive;

                while (temp != null)
                {
                    temp.DumpNode();

                    temp = temp.pNext;
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("No Active Node Detail Available");
            }
        }
    }
}