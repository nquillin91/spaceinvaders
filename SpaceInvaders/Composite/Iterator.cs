﻿using System;
using System.Diagnostics;

namespace SpaceInvaders.Composites
{
    abstract public class Iterator
    {
        abstract public Component First();
        abstract public Component Next();
        abstract public bool IsDone();

        static public Component GetParent(Component pNode)
        {
            Debug.Assert(pNode != null);

            return pNode.pParent;
        }

        static public Component GetChild(Component pNode)
        {
            Debug.Assert(pNode != null);

            Component pChild;

            if (pNode.holder == Component.Container.COMPOSITE)
            {
                pChild = pNode.GetFirstChild();
            }
            else
            {
                pChild = null;
            }

            return pChild;
        }

        static public Component GetSibling(Component pNode)
        {
            Debug.Assert(pNode != null);

            return (Component)pNode.pNext;
        }
    }
}
