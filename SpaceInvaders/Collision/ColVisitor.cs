using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using System;
using System.Diagnostics;


namespace SpaceInvaders.Collision
{
    abstract public class ColVisitor : DLink
    {

        public virtual void VisitGroup(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitColumn(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitCrab(Crab b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitOctopus(Octopus b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitSquid(Squid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Squid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitMissileGroup(MissileGroup m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitPlayerShip(PlayerShip b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by PlayerShip not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitPlayerRoot(PlayerRoot b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by PlayerRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitNullGameObject(NullGameObject n)
        {
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(ColVisitor other);
    }
}