﻿using SpaceInvaders.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Images
{
    class ImageFactory
    {
        public void LoadAllImages()
        {
            ImageManager.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 3, 3, 12, 8);
            ImageManager.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 18, 3, 12, 8);
            ImageManager.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 33, 3, 11, 8);
            ImageManager.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 47, 3, 11, 8);
            ImageManager.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 61, 3, 8, 8);
            ImageManager.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 72, 3, 8, 8);
            ImageManager.Add(Image.Name.AlienExplosion, Texture.Name.SpaceInvaders, 83, 3, 13, 8);
            ImageManager.Add(Image.Name.Saucer, Texture.Name.SpaceInvaders, 99, 3, 16, 8);
            ImageManager.Add(Image.Name.SaucerExplosion, Texture.Name.SpaceInvaders, 118, 3, 21, 8);

            ImageManager.Add(Image.Name.Player, Texture.Name.SpaceInvaders, 3, 14, 13, 8);
            ImageManager.Add(Image.Name.PlayerExplosionA, Texture.Name.SpaceInvaders, 19, 14, 16, 8);
            ImageManager.Add(Image.Name.PlayerExplosionB, Texture.Name.SpaceInvaders, 38, 14, 16, 8);
            ImageManager.Add(Image.Name.AlienPullYA, Texture.Name.SpaceInvaders, 57, 14, 15, 8);
            ImageManager.Add(Image.Name.AlienPullYB, Texture.Name.SpaceInvaders, 75, 14, 15, 8);
            ImageManager.Add(Image.Name.AlienPullUpisdeDownYA, Texture.Name.SpaceInvaders, 93, 14, 14, 8);
            ImageManager.Add(Image.Name.AlienPullUpsideDownYB, Texture.Name.SpaceInvaders, 110, 14, 14, 8);

            ImageManager.Add(Image.Name.PlayerShot, Texture.Name.SpaceInvaders, 3, 29, 1, 4);
            ImageManager.Add(Image.Name.PlayerShotExplosion, Texture.Name.SpaceInvaders, 7, 25, 8, 8);
            ImageManager.Add(Image.Name.SquigglyShotA, Texture.Name.SpaceInvaders, 18, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotB, Texture.Name.SpaceInvaders, 24, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotC, Texture.Name.SpaceInvaders, 30, 26, 3, 7);
            ImageManager.Add(Image.Name.SquigglyShotD, Texture.Name.SpaceInvaders, 36, 26, 3, 7);
            ImageManager.Add(Image.Name.PlungerShotA, Texture.Name.SpaceInvaders, 42, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotB, Texture.Name.SpaceInvaders, 48, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotC, Texture.Name.SpaceInvaders, 54, 27, 3, 6);
            ImageManager.Add(Image.Name.PlungerShotD, Texture.Name.SpaceInvaders, 60, 27, 3, 6);
            ImageManager.Add(Image.Name.RollingShotA, Texture.Name.SpaceInvaders, 65, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotB, Texture.Name.SpaceInvaders, 70, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotC, Texture.Name.SpaceInvaders, 75, 26, 3, 7);
            ImageManager.Add(Image.Name.RollingShotD, Texture.Name.SpaceInvaders, 80, 26, 3, 7);
            ImageManager.Add(Image.Name.AlienShotExplosion, Texture.Name.SpaceInvaders, 86, 25, 6, 8);

            ImageManager.Add(Image.Name.A, Texture.Name.SpaceInvaders, 3, 36, 5, 7);
            ImageManager.Add(Image.Name.B, Texture.Name.SpaceInvaders, 11, 36, 5, 7);
            ImageManager.Add(Image.Name.C, Texture.Name.SpaceInvaders, 19, 36, 5, 7);
            ImageManager.Add(Image.Name.D, Texture.Name.SpaceInvaders, 27, 36, 5, 7);
            ImageManager.Add(Image.Name.E, Texture.Name.SpaceInvaders, 35, 36, 5, 7);
            ImageManager.Add(Image.Name.F, Texture.Name.SpaceInvaders, 43, 36, 5, 7);
            ImageManager.Add(Image.Name.G, Texture.Name.SpaceInvaders, 51, 36, 5, 7);
            ImageManager.Add(Image.Name.H, Texture.Name.SpaceInvaders, 59, 36, 5, 7);
            ImageManager.Add(Image.Name.I, Texture.Name.SpaceInvaders, 67, 36, 5, 7);
            ImageManager.Add(Image.Name.J, Texture.Name.SpaceInvaders, 75, 36, 5, 7);
            ImageManager.Add(Image.Name.K, Texture.Name.SpaceInvaders, 83, 36, 5, 7);
            ImageManager.Add(Image.Name.L, Texture.Name.SpaceInvaders, 91, 36, 5, 7);
            ImageManager.Add(Image.Name.M, Texture.Name.SpaceInvaders, 99, 36, 5, 7);

            ImageManager.Add(Image.Name.N, Texture.Name.SpaceInvaders, 3, 46, 5, 7);
            ImageManager.Add(Image.Name.O, Texture.Name.SpaceInvaders, 11, 46, 5, 7);
            ImageManager.Add(Image.Name.P, Texture.Name.SpaceInvaders, 19, 46, 5, 7);
            ImageManager.Add(Image.Name.Q, Texture.Name.SpaceInvaders, 27, 46, 5, 7);
            ImageManager.Add(Image.Name.R, Texture.Name.SpaceInvaders, 35, 46, 5, 7);
            ImageManager.Add(Image.Name.S, Texture.Name.SpaceInvaders, 43, 46, 5, 7);
            ImageManager.Add(Image.Name.T, Texture.Name.SpaceInvaders, 51, 46, 5, 7);
            ImageManager.Add(Image.Name.U, Texture.Name.SpaceInvaders, 59, 46, 5, 7);
            ImageManager.Add(Image.Name.V, Texture.Name.SpaceInvaders, 67, 46, 5, 7);
            ImageManager.Add(Image.Name.W, Texture.Name.SpaceInvaders, 75, 46, 5, 7);
            ImageManager.Add(Image.Name.X, Texture.Name.SpaceInvaders, 83, 46, 5, 7);
            ImageManager.Add(Image.Name.Y, Texture.Name.SpaceInvaders, 91, 46, 5, 7);
            ImageManager.Add(Image.Name.Z, Texture.Name.SpaceInvaders, 99, 46, 5, 7);

            ImageManager.Add(Image.Name.Zero, Texture.Name.SpaceInvaders, 3, 56, 5, 7);
            ImageManager.Add(Image.Name.One, Texture.Name.SpaceInvaders, 11, 56, 5, 7);
            ImageManager.Add(Image.Name.Two, Texture.Name.SpaceInvaders, 19, 56, 5, 7);
            ImageManager.Add(Image.Name.Three, Texture.Name.SpaceInvaders, 27, 56, 5, 7);
            ImageManager.Add(Image.Name.Four, Texture.Name.SpaceInvaders, 35, 56, 5, 7);
            ImageManager.Add(Image.Name.Five, Texture.Name.SpaceInvaders, 43, 56, 5, 7);
            ImageManager.Add(Image.Name.Six, Texture.Name.SpaceInvaders, 51, 56, 5, 7);
            ImageManager.Add(Image.Name.Seven, Texture.Name.SpaceInvaders, 59, 56, 5, 7);
            ImageManager.Add(Image.Name.Eight, Texture.Name.SpaceInvaders, 67, 56, 5, 7);
            ImageManager.Add(Image.Name.Nine, Texture.Name.SpaceInvaders, 75, 56, 5, 7);
            ImageManager.Add(Image.Name.LessThan, Texture.Name.SpaceInvaders, 83, 56, 5, 7);
            ImageManager.Add(Image.Name.GreaterThan, Texture.Name.SpaceInvaders, 91, 56, 5, 7);
            ImageManager.Add(Image.Name.Space, Texture.Name.SpaceInvaders, 99, 56, 5, 7);
            ImageManager.Add(Image.Name.Equals, Texture.Name.SpaceInvaders, 107, 56, 5, 7);
            ImageManager.Add(Image.Name.Asterisk, Texture.Name.SpaceInvaders, 115, 56, 5, 7);
            ImageManager.Add(Image.Name.Question, Texture.Name.SpaceInvaders, 123, 56, 5, 7);
            ImageManager.Add(Image.Name.Hyphen, Texture.Name.SpaceInvaders, 131, 56, 5, 7);

            ImageManager.Add(Image.Name.Brick, Texture.Name.Shields, 20, 210, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top0, Texture.Name.Shields, 15, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top1, Texture.Name.Shields, 15, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Shields, 35, 215, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top0, Texture.Name.Shields, 75, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top1, Texture.Name.Shields, 75, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Bottom, Texture.Name.Shields, 55, 215, 10, 5);
        }
    }
}
