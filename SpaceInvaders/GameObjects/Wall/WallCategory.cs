﻿using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class WallCategory : Leaf
    {
        protected WallCategory.Type type;

        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,
            Unitialized
        }

        protected WallCategory(GameObject.Name name, GameSprite.Name spriteName, WallCategory.Type type)
            : base(name, spriteName)
        {
            this.type = type;
        }

        ~WallCategory()
        {
        }

        public WallCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}