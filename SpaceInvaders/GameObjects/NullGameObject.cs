using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public class NullGameObject : Leaf
    {
        public NullGameObject()
            : base(GameObject.Name.NullObject, GameSprite.Name.NullObject)
        {

        }

        ~NullGameObject()
        {

        }

        public override void Accept(ColVisitor other)
        {       
            other.VisitNullGameObject(this);
        }

        public override void Update()
        {
            // do nothing - its a null object
        }
    }
}
