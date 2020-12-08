using SpaceInvaders.Batches;
using SpaceInvaders.Images;
using SpaceInvaders.Sprites;
using SpaceInvaders.Textures;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        Composite pGrid;

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("SpaceInvaders");
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
            InitializeResources();

            SpriteBatchManager.Add(SpriteBatch.Name.Aliens, 5, 3, 150);

            AnimationSpriteCommand pSquidAnimation = new AnimationSpriteCommand(GameSprite.Name.Squid);
            pSquidAnimation.Attach(Image.Name.SquidA);
            pSquidAnimation.Attach(Image.Name.SquidB);

            AnimationSpriteCommand pCrabAnimation = new AnimationSpriteCommand(GameSprite.Name.Crab);
            pCrabAnimation.Attach(Image.Name.CrabA);
            pCrabAnimation.Attach(Image.Name.CrabB);

            AnimationSpriteCommand pOctopusAnimation = new AnimationSpriteCommand(GameSprite.Name.Octopus);
            pOctopusAnimation.Attach(Image.Name.OctopusA);
            pOctopusAnimation.Attach(Image.Name.OctopusB);

            // add AnimationSprite to timer
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, pSquidAnimation, 0.5f);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, pCrabAnimation, 0.5f);
            TimerManager.Add(TimerEvent.Name.SpriteAnimation, pOctopusAnimation, 0.5f);

            GameObject pGameObj;

            // create the factory 
            pGrid = new Composite();
            Composite pCol0 = new Composite();

            AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens);

            // Create Column 0
            pGameObj = alienFactory.Create(GameObject.Type.Squid, 10.0f * 50.0f, 500.0f);
            pCol0.Add(pGameObj);

            pGameObj = alienFactory.Create(GameObject.Type.Crab, 10.0f * 50.0f, 350.0f);
            pCol0.Add(pGameObj);

            pGameObj = alienFactory.Create(GameObject.Type.Crab, 10.0f * 50.0f, 300.0f);
            pCol0.Add(pGameObj);

            pGameObj = alienFactory.Create(GameObject.Type.Octopus, 10.0f * 50.0f, 100.0f);
            pCol0.Add(pGameObj);

            pGameObj = alienFactory.Create(GameObject.Type.Octopus, 10.0f * 50.0f, 150.0f);
            pCol0.Add(pGameObj);

            // Add to Grid
            pGrid.Add(pCol0);

            pGrid.Print();

            //---------------------------------------------------------------------------------------------------------
            // Demo variables
            //---------------------------------------------------------------------------------------------------------

            Debug.WriteLine("(Width,Height): {0}, {1}", this.GetScreenWidth(), this.GetScreenHeight());
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

            TimerManager.Update(this.GetTime());

            pGrid.Move();

            GameObjectManager.Update();
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
            SpriteBatchManager.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            SpriteBatchManager.Destroy();
            GameSpriteManager.Destroy();
            ImageManager.Destroy();
            TextureManager.Destroy();
        }

        private void InitializeResources()
        {
            TextureManager.Create(5, 2);
            ImageManager.Create(5, 3);
            GameSpriteManager.Create(20, 10);
            BoxSpriteManager.Create(5, 2);
            SpriteBatchManager.Create(5, 2);
            TimerManager.Create(3, 2);
            GameObjectManager.Create(3, 2);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");

            //---------------------------------------------------------------------------------------------------------
            // Create the Images
            //---------------------------------------------------------------------------------------------------------

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

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            GameSpriteManager.Add(GameSprite.Name.Squid, Image.Name.SquidA, 25.0f, 580.0f, 25.0f, 25.0f);
            GameSpriteManager.Add(GameSprite.Name.Crab, Image.Name.CrabA, 75.0f, 540.0f, 25.0f, 25.0f);
            GameSpriteManager.Add(GameSprite.Name.Octopus, Image.Name.OctopusA, 125.0f, 500.0f, 25.0f, 25.0f);
        }
    }
}

