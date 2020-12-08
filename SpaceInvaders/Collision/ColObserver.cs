using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Collision
{
    abstract public class ColObserver : DLink
    {
        public ColSubject pSubject;

        public abstract void Notify();

        public virtual void Execute()
        {
            // default implementation
        }
    }
}
