using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Fonts;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Images;
using SpaceInvaders.Observers;
using SpaceInvaders.Player;
using SpaceInvaders.Scenes;
using SpaceInvaders.Shield;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.States;
using SpaceInvaders.Textures;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Game : Azul.Game
    {
        public static int SCREEN_WIDTH = 1200;
        public static int SCREEN_HEIGHT = 1000;

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
            this.SetWidthHeight(SCREEN_WIDTH, SCREEN_HEIGHT);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            InitializeResources();

            SceneManager.LoadScene(SceneManager.SceneName.SelectScreen);

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
            SceneManager.Update(this.GetTime());
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
            SceneManager.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            BoxSpriteManager.Destroy();
            GameSpriteManager.Destroy();
            ImageManager.Destroy();
            TextureManager.Destroy();
            SoundManager.Destroy();
        }

        private void InitializeResources()
        {
            TextureManager.Create(1, 1);
            ImageManager.Create(5, 2);
            GameSpriteManager.Create(4, 2);
            BoxSpriteManager.Create(3, 1);
            SoundManager.Create(5, 2);
            SpriteBatchManager.Create(3, 1);
            GlyphManager.Create(3, 1);
            FontManager.Create(1, 1);
            SceneManager.Create();


            //---------------------------------------------------------------------------------------------------------
            // Sound Engine Setup
            //---------------------------------------------------------------------------------------------------------

            AudioFactory audioFactory = new AudioFactory();
            audioFactory.LoadAllAudio();

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            TextureFactory textureFactory = new TextureFactory();
            textureFactory.LoadTextures();

            //---------------------------------------------------------------------------------------------------------
            // Create the Images
            //---------------------------------------------------------------------------------------------------------

            ImageFactory imageFactory = new ImageFactory();
            imageFactory.LoadAllImages();

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            GameSpriteFactory gameSpriteFactory = new GameSpriteFactory();
            gameSpriteFactory.LoadSprites();

            BoxSpriteFactory boxSpriteFactory = new BoxSpriteFactory();
            boxSpriteFactory.LoadSprites();
        }
    }
}

