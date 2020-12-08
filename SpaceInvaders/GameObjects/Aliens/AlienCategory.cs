using SpaceInvaders.Composites;
using SpaceInvaders.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameObjects
{
    abstract public class AlienCategory : Leaf
    {
        public enum Type
        {
            // temporary location --> move this
            Crab,
            Squid,
            Octopus,

            Column,
            Grid,

            Unitialized
        }

        public AlienCategory(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {
            this.instanceId = UUIDGenerator.GetNewId();
        }
    }
}
