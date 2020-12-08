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
        protected int points;

        public enum Type
        {
            // temporary location --> move this
            Crab,
            Squid,
            Octopus,

            UFO,
            UFORoot,

            Column,
            Grid,

            Unitialized
        }

        public AlienCategory(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {
            this.instanceId = UUIDGenerator.GetNewId();
        }

        public int GetPoints()
        {
            return this.points;
        }
    }
}