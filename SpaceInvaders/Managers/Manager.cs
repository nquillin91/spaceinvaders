using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Manager
    {
        protected DLink poActiveList;
        protected DLink poActiveListTail;
        protected DLink poReserveList;
        protected DLink poReserveListTail;

        protected int growthSize = 0;
        protected int initialReserveSize = 0;

        protected Manager(int reserveSize, int growthSize)
        {
            this.SetManagerDefaults(reserveSize, growthSize);
        }

        protected void SetManagerDefaults(int reserveSize, int growthSize)
        {
            Debug.Assert(growthSize > 0);
            Debug.Assert(reserveSize >= 0);

            this.growthSize = growthSize;
            this.initialReserveSize = reserveSize;

            this.GenerateReserveNodes(reserveSize);
        }

        protected void GenerateReserveNodes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                DLink pNewNode = this.CreateNode();
                
                if (poReserveList == null)
                {
                    poReserveList = poReserveListTail = pNewNode;
                } else
                {
                    DLink.AddFirst(ref poReserveList, ref poReserveListTail, ref pNewNode);
                }

                poReserveList.size++;
            }
        }

        protected DLink BaseAddNode()
        {
            if (poReserveList.size == 0)
            {
                this.GenerateReserveNodes(this.growthSize);
            }

            DLink pLink = DLink.RemoveFromFront(ref poReserveList);

            Debug.Assert(pLink != null);
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);

            DLink.AddFirst(ref poActiveList, ref poActiveListTail, ref pLink);

            poActiveList.size++;
            poReserveList.size--;

            return pLink;
        }

        protected void BaseRemove(DLink pNode)
        {
            if (this.CompareNodes(poActiveList, pNode))
            {
                DLink.RemoveFromFront(ref poActiveList);
            } else
            {
                DLink.RemoveNode(ref poActiveList, ref pNode);
            }

            pNode.Wash();

            DLink.AddFirst(ref poReserveList, ref poReserveListTail, ref pNode);

            poActiveList.size--;
            poReserveList.size++;
        }

        protected DLink BaseFind(DLink pTargetNode)
        {
            DLink temp = poActiveList;

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

        private void DestroyList(DLink listHead)
        {
            while (listHead != null && listHead.size > 0)
            {
                DLink removedNode = DLink.RemoveFromFront(ref listHead);
                removedNode.Wash();
                removedNode.Destroy();
                // TODO: I cannot remember, do you need to set the variable itself to null?
                removedNode = null;
            }
        }

        public void BaseDestroy()
        {
            this.DestroyList(this.poActiveList);
            this.DestroyList(this.poReserveList);
        }

        protected abstract DLink CreateNode();
        protected abstract Boolean CompareNodes(DLink pLinkA, DLink pLinkB);

        public void PrintStats()
        {
            System.Diagnostics.Debug.WriteLine("------------- STATS --------------");
            System.Diagnostics.Debug.WriteLine("Initial Reserve Size = " + this.initialReserveSize + ", ");
            System.Diagnostics.Debug.WriteLine("Growth Size = " + this.growthSize);
            System.Diagnostics.Debug.WriteLine("Total Number in Active and Reserve = " + (this.poReserveList.size + this.poActiveList.size));
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            System.Diagnostics.Debug.WriteLine("Number in Reserve = " + this.poReserveList.size);
            if (poReserveList != null)
            {
                DLink temp = poReserveList;

                while (temp != null)
                {
                    temp.Dump();

                    temp = temp.pNext;
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("No Reserve Node Detail Available");
            }
            System.Diagnostics.Debug.WriteLine("----------------------------------------------");
            System.Diagnostics.Debug.WriteLine("Number in Active = " + this.poActiveList.size);
            if (poActiveList != null)
            {
                DLink temp = poActiveList;

                while (temp != null)
                {
                    temp.Dump();

                    temp = temp.pNext;
                }
            } else
            {
                System.Diagnostics.Debug.WriteLine("No Active Node Detail Available");
            }
        }
    }
}