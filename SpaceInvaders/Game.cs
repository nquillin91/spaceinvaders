using SpaceInvaders.Nodes;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        Sprite pRedBirdSprite;
        Sprite pWhiteBirdSprite;
        Sprite pYellowBirdSprite;
        Sprite pGreenBirdSprite;
        Sprite pAlienSprite;
        Sprite pAlienWhiteSprite;
        Sprite pStitchSprite;
        Sprite pAlienSwapSprite;
        Sprite pAlien1Sprite;
        Sprite pAlien2Sprite;
        Sprite pAlien3Sprite;
        Sprite pAlien4Sprite;
        Sprite pAlien5Sprite;
        Sprite pBird1Sprite;
        Sprite pBird2Sprite;
        Sprite pBird3Sprite;
        Sprite pBird4Sprite;

        float redSpeed = 2.0f;
        float yellowSpeedX = 2.0f;
        float yellowSpeedY = 2.0f;
        float greenBirdSpeedX = 2.0f;
        float greenBirdSpeedY = 2.0f;
        float whiteBirdSpeed = 0.02f;

        float ScreenX = 0.0f;
        float ScreenWidth = 300.0f;
        float ScreenHeight = 100.0f;

        float blue = 0.0f;
        float red = 1.0f;

        float AlienPosX = 0.0f;
        float AlienPosY = 0.0f;
        float AlienAngle = 0.0f;

        int count = 0;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("->Set Screen Title Name Here<-");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            TextureManager.Create(5, 2);
            ImageManager.Create(5, 3);
            SpriteManager.Create(20, 10);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureManager.Add(Texture.Name.Aliens, "Aliens.tga");
            TextureManager.Add(Texture.Name.Stitch, "stitch.tga");
            TextureManager.Add(Texture.Name.Birds, "Birds.tga");

            //---------------------------------------------------------------------------------------------------------
            // Create the Images
            //---------------------------------------------------------------------------------------------------------

            ImageManager.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);

            ImageManager.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);

            ImageManager.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);

            ImageManager.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);

            ImageManager.Add(Image.Name.Stitch, Texture.Name.Stitch, 0.0f, 0.0f, 300.0f, 410.0f);

            ImageManager.Add(Image.Name.Alien1, Texture.Name.Aliens, 253.0f, 63.0f, 85.0f, 64.0f);

            ImageManager.Add(Image.Name.Alien2, Texture.Name.Aliens, 136.0f, 64.0f, 85.0f, 63.0f);

            ImageManager.Add(Image.Name.Alien3, Texture.Name.Aliens, 369.0f, 64.0f, 65.0f, 63.0f);

            ImageManager.Add(Image.Name.Alien4, Texture.Name.Aliens, 464.0f, 64.0f, 65.0f, 63.0f);

            ImageManager.Add(Image.Name.Alien5, Texture.Name.Aliens, 459.0f, 200.0f, 56.0f, 64.0f);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            pRedBirdSprite = SpriteManager.Add(Sprite.Name.RedBird, Image.Name.RedBird, 50.0f, 500.0f, 50.0f, 50.0f);
            Debug.Assert(pRedBirdSprite != null);

            pWhiteBirdSprite = SpriteManager.Add(Sprite.Name.WhiteBird, Image.Name.WhiteBird, 600.0f, 200.0f, 50.0f, 50.0f);
            Debug.Assert(pWhiteBirdSprite != null);

            pYellowBirdSprite = SpriteManager.Add(Sprite.Name.YellowBird, Image.Name.YellowBird, 300.0f, 400.0f, 100.0f, 100.0f);
            Debug.Assert(pYellowBirdSprite != null);

            pGreenBirdSprite = SpriteManager.Add(Sprite.Name.GreenBird, Image.Name.GreenBird, 400.0f, 200.0f, 75.0f, 75.0f);
            Debug.Assert(pGreenBirdSprite != null);

            pAlienSprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien2, 100.0f, 0.0f, 150.0f, 150.0f);
            Debug.Assert(pAlienSprite != null);

            pAlien1Sprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien1, 25.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pAlien1Sprite != null);

            pAlien2Sprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien2, 75.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pAlien2Sprite != null);

            pAlien3Sprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien3, 125.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pAlien3Sprite != null);

            pAlien4Sprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien4, 175.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pAlien4Sprite != null);

            pAlien5Sprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien5, 225.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pAlien5Sprite != null);

            pBird1Sprite = SpriteManager.Add(Sprite.Name.RedBird, Image.Name.RedBird, 275.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pBird1Sprite != null);

            pBird2Sprite = SpriteManager.Add(Sprite.Name.WhiteBird, Image.Name.WhiteBird, 325.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pBird2Sprite != null);

            pBird3Sprite = SpriteManager.Add(Sprite.Name.YellowBird, Image.Name.YellowBird, 375.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pBird3Sprite != null);

            pBird4Sprite = SpriteManager.Add(Sprite.Name.GreenBird, Image.Name.GreenBird, 425.0f, 580.0f, 25.0f, 25.0f);
            Debug.Assert(pBird4Sprite != null);

            pAlienWhiteSprite = SpriteManager.Add(Sprite.Name.AlienWhite, Image.Name.Alien4, 500.0f, 300.0f, 150.0f, 150.0f);
            Debug.Assert(pAlienWhiteSprite != null);
            pAlienWhiteSprite.SwapColor(1.0f, 1.0f, 0.0f, 1.0f);
            
            pStitchSprite = SpriteManager.Add(Sprite.Name.Stitch, Image.Name.Stitch, 150.0f, 500.0f, 100.0f, 100.0f);
            Debug.Assert(pStitchSprite != null);

            pAlienSwapSprite = SpriteManager.Add(Sprite.Name.AlienSwap, Image.Name.Alien1, 300.0f, 300.0f, 150.0f, 150.0f);
            Debug.Assert(pAlienSwapSprite != null);
            pAlienSwapSprite.SwapColor(1.0f, 1.0f, 0.0f, 1.0f);

            //---------------------------------------------------------------------------------------------------------
            // Demo variables
            //---------------------------------------------------------------------------------------------------------

            Debug.WriteLine("(Width,Height): {0}, {1}", this.GetScreenWidth(), this.GetScreenHeight());

            AlienPosX = pAlienSprite.x;
            AlienPosY = pAlienSprite.y;
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Add your update below this line: ----------------------------

            //  InputTest.KeyboardTest();
            //  InputTest.MouseTest();

            //--------------------------------------------------------
            // Change Texture, TextureRect, Color
            //--------------------------------------------------------

            count++;
            if (count == 100)
            {
                Debug.Assert(ImageManager.Find(Image.Name.Stitch) != null);
                pAlienSprite.SwapImage(ImageManager.Find(Image.Name.Stitch));

                pAlien1Sprite.x += 5;
                pAlien2Sprite.x += 5;
                pAlien3Sprite.x += 5;
                pAlien4Sprite.x += 5;
                pAlien5Sprite.x += 5;

                pBird1Sprite.x += 5;
                pBird2Sprite.x += 5;
                pBird3Sprite.x += 5;
                pBird4Sprite.x += 5;
            }
            else if (count == 200)
            {
                Debug.Assert(ImageManager.Find(Image.Name.Alien2) != null);

                pAlienSprite.SwapImage(ImageManager.Find(Image.Name.Alien2));

                count = 0;
            }
        

            //--------------------------------------------------------
            // Alien - Angles,position
            //--------------------------------------------------------

            AlienAngle += 0.1f;
            AlienPosX += 2.0f;
            if (AlienPosX > 800.0f)
                AlienPosX = 0.0f;
            AlienPosY += 1.0f;
            if (AlienPosY > 600.0f)
                AlienPosY = 0.0f;

            pAlienSprite.x = AlienPosX;
            pAlienSprite.y = AlienPosY;
            pAlienSprite.angle = AlienAngle;
            pAlienSprite.Update();

            //--------------------------------------------------------
            // Stitch - Scale
            //--------------------------------------------------------

            pStitchSprite.scaleY = -1.0f;
            pStitchSprite.Update();

            //--------------------------------------------------------
            // Swap Color
            //--------------------------------------------------------

            blue += 0.001f;
            red -= 0.002f;
            if (red <= 0.0f)
                red = 1.0f;
            pAlienWhiteSprite.SwapColor(red, 0.0f, blue);
            pAlienWhiteSprite.Update();

            //--------------------------------------------------------
            // Swap Screen Rect
            //--------------------------------------------------------

            ScreenX += 2;
            ScreenWidth -= 1;
            ScreenHeight += 1;

            pAlienSwapSprite.SwapScreenRect(ScreenX, 100, ScreenWidth, ScreenHeight);
            pAlienSwapSprite.Update();

            //--------------------------------------------------------
            // Red Bird
            //--------------------------------------------------------
            if (pRedBirdSprite.x > this.GetScreenWidth() || pRedBirdSprite.x < 0.0f)
            {
                redSpeed *= -1.0f;
            }
            pRedBirdSprite.x += redSpeed;
            pRedBirdSprite.Update();

            //--------------------------------------------------------
            // Yellow Bird
            //--------------------------------------------------------
            if (pYellowBirdSprite.x > this.GetScreenWidth() || pYellowBirdSprite.x < 0.0f)
            {
                yellowSpeedX *= -1.0f;

                Image pYellowBirdImage = pYellowBirdSprite.pImage;
                Debug.Assert(pYellowBirdImage != null);

                pYellowBirdImage.Set(pYellowBirdImage.name, pYellowBirdImage.pTexture,
                    246, 135, 99, 72);
                pYellowBirdSprite.SwapImage(pYellowBirdImage);
                pYellowBirdSprite.Update();
                //bumpSnd = Azul.Audio.playSound("A.wav", false, true, true);
                //bumpSnd.Pause(false);
            }
            if (pYellowBirdSprite.y > this.GetScreenHeight() || pYellowBirdSprite.y < 0.0f)
            {
                //bumpSnd = Azul.Audio.playSound("A.wav", false, true, true);
                //bumpSnd.Pause(false);
                Image pYellowBirdImage = pYellowBirdSprite.pImage;
                Debug.Assert(pYellowBirdImage != null);

                pYellowBirdImage.Set(pYellowBirdImage.name, pYellowBirdImage.pTexture, 124, 34, 60, 56);
                pYellowBirdSprite.SwapImage(pYellowBirdImage);
                pYellowBirdSprite.Update();

                yellowSpeedY *= -1;
            }
            pYellowBirdSprite.x += yellowSpeedX;
            pYellowBirdSprite.y += yellowSpeedY;

            pYellowBirdSprite.Update();

            //--------------------------------------------------------
            // Green Bird
            //--------------------------------------------------------
            if (pGreenBirdSprite.x > this.GetScreenWidth() || pGreenBirdSprite.x < 0.0f)
            {
                greenBirdSpeedX *= -1.0f;
            }
            if (pGreenBirdSprite.y > this.GetScreenHeight() || pGreenBirdSprite.y < 0.0f)
            {
                greenBirdSpeedY *= -1.0f;
            }
            pGreenBirdSprite.x += greenBirdSpeedX;
            pGreenBirdSprite.y += greenBirdSpeedY;
            pGreenBirdSprite.angle += 0.05f;

            pGreenBirdSprite.Update();

            //--------------------------------------------------------
            // White Bird
            //--------------------------------------------------------
            if (pWhiteBirdSprite.scaleX > 5.0f || pWhiteBirdSprite.scaleY < 1.0f)
            {
                whiteBirdSpeed *= -1.0f;
            }
            pWhiteBirdSprite.scaleX += whiteBirdSpeed;
            pWhiteBirdSprite.scaleY += whiteBirdSpeed;

            pWhiteBirdSprite.Update();

            pAlien1Sprite.Update();
            pAlien2Sprite.Update();
            pAlien3Sprite.angle += 0.05f;
            pAlien3Sprite.Update();
            pAlien4Sprite.Update();
            pAlien5Sprite.Update();

            pBird1Sprite.Update();
            pBird2Sprite.Update();
            pBird3Sprite.Update();
            pBird4Sprite.Update();
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // draw all objects
            pAlienSprite.Render();
            pStitchSprite.Render();
            pAlienWhiteSprite.Render();
            pAlienSwapSprite.Render();
            pGreenBirdSprite.Render();
            pRedBirdSprite.Render();
            pWhiteBirdSprite.Render();
            pYellowBirdSprite.Render();

            pAlien1Sprite.Render();
            pAlien2Sprite.Render();
            pAlien3Sprite.Render();
            pAlien4Sprite.Render();
            pAlien5Sprite.Render();

            pBird1Sprite.Render();
            pBird2Sprite.Render();
            pBird3Sprite.Render();
            pBird4Sprite.Render();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

