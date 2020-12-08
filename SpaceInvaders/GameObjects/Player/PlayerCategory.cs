using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Player
{
    abstract public class PlayerCategory : Leaf
    {
        protected PlayerCategory.Type type;

        public enum Type
        {
            Player,
            PlayerRoot,
            Unitialized
        }

        protected PlayerCategory(GameObject.Name name, GameSprite.Name spriteName, PlayerCategory.Type shipType)
            : base(name, spriteName)
        {
            this.type = shipType;
        }

        ~PlayerCategory()
        {
        }
    }
}