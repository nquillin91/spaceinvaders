﻿using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Shield
{
    abstract public class ShieldCategory : Leaf
    {
        protected ShieldCategory.Type type;

        public enum Type
        {
            Root,
            Column,
            Brick,
            Grid,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Unitialized
        }
        protected ShieldCategory(GameObject.Name name, GameSprite.Name spriteName, ShieldCategory.Type shieldType)
            : base(name, spriteName)
        {
            this.type = shieldType;
        }
        // Data: ---------------
        ~ShieldCategory()
        {
        }
        public ShieldCategory.Type GetCategoryType()
        {
            return this.type;
        }
    }
}
