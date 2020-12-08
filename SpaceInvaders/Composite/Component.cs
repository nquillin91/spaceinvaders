using SpaceInvaders.Collision;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Composites
{
    public abstract class Component : ColVisitor
    {
        public Component pParent = null;
        public Component pReverse = null;
        public Container holder = Container.Unknown;

        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract Component GetFirstChild();
    }
}
