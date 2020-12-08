using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class GameSpriteChangeColorCommand : Command
    {
        private GameSprite pSprite;
        private Azul.Color pColor;

        public GameSpriteChangeColorCommand(GameSprite.Name spriteName, Azul.Color pColor)
        {
            // initialized the sprite animation is attached to
            this.pSprite = GameSpriteManager.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            this.pColor = pColor;
            Debug.Assert(this.pColor != null);
        }

        public override void Execute(float deltaTime)
        {
            // change image
            this.pSprite.SwapColor(this.pColor.red, this.pColor.green, this.pColor.blue, this.pColor.alpha);
        }
    }
}
