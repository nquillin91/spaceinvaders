using SpaceInvaders.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Sprites
{
    class GameSpriteFactory
    {
        public void LoadSprites()
        {
            GameSpriteManager.Add(GameSprite.Name.Squid, Image.Name.SquidA, 550.0f, 350.0f, 20.0f, 20.0f);
            GameSpriteManager.Add(GameSprite.Name.Crab, Image.Name.CrabA, 550.0f, 300.0f, 20.0f, 20.0f);
            GameSpriteManager.Add(GameSprite.Name.Octopus, Image.Name.OctopusA, 550.0f, 250.0f, 20.0f, 20.0f);
            GameSpriteManager.Add(GameSprite.Name.DeadAlien, Image.Name.AlienExplosion, 175.0f, 500.0f, 20.0f, 20.0f);
            GameSpriteManager.Add(GameSprite.Name.UFO, Image.Name.Saucer, 550.0f, 400.0f, 35.0f, 20.0f, new Azul.Color(1.0f, 0.0f, 0.0f));
            GameSpriteManager.Add(GameSprite.Name.DeadUFO, Image.Name.SaucerExplosion, 125.0f, 500.0f, 35.0f, 20.0f, new Azul.Color(1.0f, 0.0f, 0.0f));
            GameSpriteManager.Add(GameSprite.Name.Missile, Image.Name.PlayerShot, 50, 50, 5, 20);
            GameSpriteManager.Add(GameSprite.Name.DeadMissile, Image.Name.PlayerShotExplosion, 50, 50, 10, 20, new Azul.Color(1.0f, 0.0f, 0.0f));
            GameSpriteManager.Add(GameSprite.Name.Player, Image.Name.Player, 50, 50, 30, 30, new Azul.Color(0.1f, 1.0f, 0.4f));
            GameSpriteManager.Add(GameSprite.Name.DeadPlayer1, Image.Name.PlayerExplosionA, 50, 50, 30, 30, new Azul.Color(0.1f, 1.0f, 0.4f));
            GameSpriteManager.Add(GameSprite.Name.DeadPlayer2, Image.Name.PlayerExplosionB, 50, 50, 30, 30, new Azul.Color(0.1f, 1.0f, 0.4f));
            GameSpriteManager.Add(GameSprite.Name.Wall, Image.Name.Hyphen, 40, 185, 20, 10);

            GameSpriteManager.Add(GameSprite.Name.BombZigZag, Image.Name.SquigglyShotA, 200, 200, 10, 30);
            GameSpriteManager.Add(GameSprite.Name.BombStraight, Image.Name.RollingShotA, 100, 100, 10, 30);
            GameSpriteManager.Add(GameSprite.Name.BombDagger, Image.Name.PlungerShotA, 100, 100, 10, 30);

            GameSpriteManager.Add(GameSprite.Name.Brick, Image.Name.Brick, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 20, 10);
            GameSpriteManager.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 20, 10);
        }
    }
}
