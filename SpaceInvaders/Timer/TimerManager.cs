using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class TimerManager : Manager
    {
        private static TimerManager pTimerManager;
        private readonly TimerEvent poCompareNode;
        private float mCurrentTime;
        
        private TimerManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (TimerEvent)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pTimerManager == null)
            {
                pTimerManager = new TimerManager(reserveSize, growthSize);
            }
        }

        public static TimerManager GetInstance()
        {
            Debug.Assert(pTimerManager != null);

            return pTimerManager;
        }

        public static TimerEvent Add(TimerEvent.Name eventName, Command pCommand, float deltaTimeToTrigger)
        {
            TimerManager timerManager = TimerManager.GetInstance();
            
            TimerEvent timerEvent = (TimerEvent)timerManager.AddNodeBySpecifiedTime(deltaTimeToTrigger);
            timerEvent.Set(eventName, pCommand, deltaTimeToTrigger);

            return timerEvent;
        }

        public static void Remove(TimerEvent spriteBatch)
        {
            Debug.Assert(spriteBatch != null);

            TimerManager spriteBatchMan = TimerManager.GetInstance();
            Debug.Assert(spriteBatchMan != null);

            spriteBatchMan.BaseRemove(spriteBatch);
        }

        public static TimerEvent Find(TimerEvent.Name name)
        {
            TimerManager timerManager = TimerManager.GetInstance();

            timerManager.poCompareNode.Wash();
            timerManager.poCompareNode.name = name;

            TimerEvent spriteBatch = (TimerEvent)timerManager.BaseFind(timerManager.poCompareNode);

            return spriteBatch;
        }

        public static void Update(float currentTime)
        {
            TimerManager timerManager = TimerManager.GetInstance();

            timerManager.mCurrentTime = currentTime;

            TimerEvent temp = (TimerEvent)timerManager.poActiveList;
            TimerEvent pTempNext;

            while (temp != null)
            {
                pTempNext = (TimerEvent)temp.pNext;

                if (timerManager.mCurrentTime >= temp.triggerTime)
                {
                    temp.Process();

                    timerManager.BaseRemove(temp);
                } else
                {
                    // This will kick us out of the loop the moment we hit the first event
                    // that isn't ready to be triggered. This works because we insert in order by triggerTime;
                    break;
                }

                temp = pTempNext;
            }
        }

        public static float GetCurrentTime()
        {
            TimerManager timerManager = TimerManager.GetInstance();
            Debug.Assert(timerManager != null);

            return timerManager.mCurrentTime;
        }

        private DLink AddNodeBySpecifiedTime(float deltaTimeToTrigger)
        {
            if (this.poReserveList.size == 0)
            {
                this.GenerateReserveNodes(this.growthSize);
            }

            DLink pLink = DLink.RemoveFromFront(ref this.poReserveList);

            Debug.Assert(pLink != null);
            Debug.Assert(pLink.pNext == null);
            Debug.Assert(pLink.pPrev == null);

            DLink temp = this.poActiveList;

            if (temp == null)
            {
                DLink.AddFirst(ref this.poActiveList, ref this.poActiveListTail, pLink);
            } else
            {
                while (temp != null)
                {
                    float triggerTime = TimerManager.GetCurrentTime() + deltaTimeToTrigger;
                    if (triggerTime <= ((TimerEvent)temp).triggerTime)
                    {
                        DLink.InsertBeforeNode(ref this.poActiveList, ref temp, ref pLink);
                        break;
                    }

                    if (temp.pNext == null)
                    {
                        DLink.InsertAfterNode(ref this.poActiveList, ref temp, ref pLink);
                        break;
                    }

                    temp = temp.pNext;
                }
            }

            this.poActiveList.size++;
            this.poReserveList.size--;

            return pLink;
        }

        protected override DLink CreateNode()
        {
            TimerEvent spriteBatch = new TimerEvent();
            Debug.Assert(spriteBatch != null);

            return spriteBatch;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            TimerEvent spriteBatchA = (TimerEvent)pLinkA;
            TimerEvent spriteBatchB = (TimerEvent)pLinkB;

            if (spriteBatchA.name == spriteBatchB.name)
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            TimerManager spriteBatchMan = TimerManager.GetInstance();
            Debug.Assert(spriteBatchMan != null);
            spriteBatchMan.BaseDestroy();
        }
    }
}
