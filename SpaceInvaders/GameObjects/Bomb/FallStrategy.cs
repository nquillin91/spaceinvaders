using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class FallStrategy
    {
        public enum Type
        {
            Dagger,
            Straight,
            ZigZag
        }

        abstract public void Fall(Bomb pBomb);
        abstract public void Reset(float posY);

    }
}
