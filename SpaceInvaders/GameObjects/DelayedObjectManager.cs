
using SpaceInvaders.Collision;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    class DelayedObjectManager
    {
        private ColObserver head;
        private static DelayedObjectManager instance = null;

        private DelayedObjectManager()
        {
            this.head = null;
        }

        private static DelayedObjectManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DelayedObjectManager();
            }

            Debug.Assert(instance != null);

            return instance;
        }

        static public void Attach(ColObserver observer)
        {
            Debug.Assert(observer != null);

            DelayedObjectManager pDelayMan = DelayedObjectManager.GetInstance();

            if (pDelayMan.head == null)
            {
                pDelayMan.head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = pDelayMan.head;
                observer.pPrev = null;
                pDelayMan.head.pPrev = observer;
                pDelayMan.head = observer;
            }
        }

        private void Detach(ColObserver node, ref ColObserver head)
        {
            Debug.Assert(node != null);

            if (node.pPrev != null)
            {
                node.pPrev.pNext = node.pNext;
            }
            else
            {
                head = (ColObserver)node.pNext;
            }

            if (node.pNext != null)
            {
                node.pNext.pPrev = node.pPrev;
            }
        }

        static public void Process()
        {
            DelayedObjectManager pDelayMan = DelayedObjectManager.GetInstance();
            ColObserver pNode = pDelayMan.head;

            while (pNode != null)
            {
                pNode.Execute();

                pNode = (ColObserver)pNode.pNext;
            }

            pNode = pDelayMan.head;
            ColObserver pTmp = null;

            while (pNode != null)
            {
                pTmp = pNode;
                pNode = (ColObserver)pNode.pNext;
                pDelayMan.Detach(pTmp, ref pDelayMan.head);
            }
        }
    }
}