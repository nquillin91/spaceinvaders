using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Shield;
using System;
using System.Diagnostics;


namespace SpaceInvaders.Collision
{
    abstract public class ColVisitor : DLink
    {

        public virtual void VisitAlienGrid(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGrid not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitAlienColumn(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUFO(UFO u)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitUFORoot(UFORoot u)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Crab not implemented");
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

        public virtual void VisitBomb(Bomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitBombRoot(BombRoot b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BombRoot not implemented");
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

        public virtual void VisitWallGroup(WallGroup w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallTop(WallTop w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallBottom(WallBottom w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallLeft(WallLeft w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitWallRight(WallRight w)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldBrick(ShieldBrick s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldRoot(ShieldRoot s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldRoot not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldColumn(ShieldColumn s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldGrid(ShieldGrid s)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by ShieldGrid not implemented");
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