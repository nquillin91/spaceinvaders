﻿using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Timer
{
    class AnimationSpriteCommand : Command
    {
        private GameSprite pSprite;
        private SLink pCurrImage;
        private SLink poFirstImage;

        public AnimationSpriteCommand(GameSprite.Name spriteName)
        {
            // initialized the sprite animation is attached to
            this.pSprite = GameSpriteManager.Find(spriteName);
            Debug.Assert(this.pSprite != null);

            // initialize references
            this.pCurrImage = null;

            // list
            this.poFirstImage = null;
        }

        public void Attach(Image.Name imageName)
        {
            // Get the image
            Image pImage = ImageManager.Find(imageName);
            Debug.Assert(pImage != null);

            // Create a new holder
            ImageHolder pImageHolder = new ImageHolder(pImage);
            Debug.Assert(pImageHolder != null);

            // Attach it to the Animation Sprite ( Push to front )
            SLink.AddFirst(ref this.poFirstImage, pImageHolder);

            // Set the first one to this image
            this.pCurrImage = pImageHolder;
        }

        public override void Execute(float deltaTime)
        {
            // advance to next image 
            ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.pNext;

            // if at end of list, set to first
            if (pImageHolder == null)
            {
                pImageHolder = (ImageHolder)poFirstImage;
            }

            // squirrel away for next timer event
            this.pCurrImage = pImageHolder;

            // change image
            this.pSprite.SwapImage(pImageHolder.pImage);

            // Add itself back to timer
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, this, deltaTime);
        }
    }
}
