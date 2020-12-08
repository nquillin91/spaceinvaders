using SpaceInvaders.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprites
{
    class BoxSpriteFactory
    {
        public void LoadSprites()
        {
            BoxSpriteManager.Add(BoxSprite.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            BoxSpriteManager.Add(BoxSprite.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);
        }
    }
}
