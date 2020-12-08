using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Collision
{
    public class ColPair : DLink
    {
        public ColSubject poSubject;
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;

        public enum Name
        {
            Missile,
            MissileWall,
            MissileShield,

            BombShield,
            BombWall,
            BombAlien,

            NullObject,
            Not_Initialized
        }

        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;

            this.poSubject = new ColSubject();
            Debug.Assert(this.poSubject != null);
        }

        ~ColPair()
        {

        }

        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }

        public void SetName(ColPair.Name inName)
        {
            this.name = inName;
        }

        public override void Wash()
        {
            base.Wash();

            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }

        public ColPair.Name GetName()
        {
            return this.name;
        }

        public void Process()
        {
            Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // A vs B
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                // Restart compare
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {
                    // Get rectangles
                    ColRect rectA = pNodeA.GetColObject().poColRect;
                    ColRect rectB = pNodeB.GetColObject().poColRect;

                    // test them
                    if (ColRect.Intersect(rectA, rectB))
                    {
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }

        public void Attach(ColObserver observer)
        {
            this.poSubject.Attach(observer);
        }

        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }

        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            this.poSubject.pObjA = pObjA;
            this.poSubject.pObjB = pObjB;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}