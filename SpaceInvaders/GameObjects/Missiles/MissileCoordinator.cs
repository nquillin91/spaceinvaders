using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    abstract public class MissileCoordinator : Leaf
    {
        public float delta = 7.5f;

        public MissileCoordinator(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {
            this.instanceId = UUIDGenerator.GetNewId();
        }

        public override void Update()
        {
            this.y += delta;
            base.Update();
        }
    }
}
