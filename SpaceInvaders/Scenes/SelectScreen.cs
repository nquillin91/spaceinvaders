using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Fonts;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Images;
using SpaceInvaders.Observers;
using SpaceInvaders.Player;
using SpaceInvaders.Shield;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Scenes
{
    class SelectScreen : Scene
    {
        public override void LoadScene()
        {
            AlienManager.Create();

            LoadWalls();
            LoadAliens();
            LoadText();

            HUDManager.Setup();
        }

        public override void Update(float time)
        {
            base.Update(time);

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1))
            {
                PlayerManager.SetPlayerNumber(PlayerManager.PlayerNumber.Player1);
                this.markedForTransition = true;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2))
            {
                PlayerManager.SetPlayerNumber(PlayerManager.PlayerNumber.Player2);
                this.markedForTransition = true;
            }
        }

        public override void Transition()
        {
            SceneManager.LoadScene(SceneManager.SceneName.Round1);
        }

        private void LoadWalls()
        {
            this.pWallGroup = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Aliens));

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, GameSprite.Name.Wall, 600, 700, 1200, 100);
            pWallTop.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, GameSprite.Name.Wall, 600, 22, 1200, 50);
            pWallBottom.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, GameSprite.Name.Wall, 1200, 350, 20, 600);
            pWallRight.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, GameSprite.Name.Wall, 0, 350, 20, 600);
            pWallLeft.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            // Add to the composite the children
            this.pWallGroup.Add(pWallTop);
            this.pWallGroup.Add(pWallBottom);
            this.pWallGroup.Add(pWallRight);
            this.pWallGroup.Add(pWallLeft);

            GameObjectManager.Attach(this.pWallGroup);
        }

        private void LoadAliens()
        {
            ProxySprite pProxySprite;
            
            pProxySprite = ProxySpriteManager.Add(GameSprite.Name.UFO);
            pProxySprite.x = 550.0f;
            pProxySprite.y = 400.0f;
            SpriteBatchManager.Find(SpriteBatch.Name.HUD).Attach(pProxySprite);

            pProxySprite = ProxySpriteManager.Add(GameSprite.Name.Squid);
            pProxySprite.x = 550.0f;
            pProxySprite.y = 350.0f;
            SpriteBatchManager.Find(SpriteBatch.Name.HUD).Attach(pProxySprite);

            pProxySprite = ProxySpriteManager.Add(GameSprite.Name.Crab);
            pProxySprite.x = 550.0f;
            pProxySprite.y = 300.0f;
            SpriteBatchManager.Find(SpriteBatch.Name.HUD).Attach(pProxySprite);

            pProxySprite = ProxySpriteManager.Add(GameSprite.Name.Octopus);
            pProxySprite.x = 550.0f;
            pProxySprite.y = 250.0f;
            SpriteBatchManager.Find(SpriteBatch.Name.HUD).Attach(pProxySprite);
        }

        private void LoadText()
        {
            Font pPlayText = FontManager.Add(Font.Name.Play, SpriteBatch.Name.HUD, "PLAY", Glyph.Name.Consolas36pt, 585, 550);
            pPlayText.SetColor(1.0f, 1.0f, 1.0f);

            Font pSpaceText = FontManager.Add(Font.Name.Space, SpriteBatch.Name.HUD, "SPACE", Glyph.Name.Consolas36pt, 425, 500);
            pSpaceText.SetColor(1.0f, 1.0f, 1.0f);

            Font pInvadersText = FontManager.Add(Font.Name.Invaders, SpriteBatch.Name.HUD, "INVADERS", Glyph.Name.Consolas36pt, 700, 500);
            pInvadersText.SetColor(1.0f, 1.0f, 1.0f);

            Font pUfoPoints = FontManager.Add(Font.Name.UFOPoints, SpriteBatch.Name.HUD, " = ?", Glyph.Name.Consolas36pt, 625.0f, 400.0f);
            pUfoPoints.SetColor(1.0f, 1.0f, 1.0f);

            Font pSquidPoints = FontManager.Add(Font.Name.SquidPoints, SpriteBatch.Name.HUD, " = 30", Glyph.Name.Consolas36pt, 625.0f, 350.0f);
            pSquidPoints.SetColor(1.0f, 1.0f, 1.0f);

            Font pCrabPoints = FontManager.Add(Font.Name.CrabPoints, SpriteBatch.Name.HUD, " = 20", Glyph.Name.Consolas36pt, 625.0f, 300.0f);
            pCrabPoints.SetColor(1.0f, 1.0f, 1.0f);

            Font pOctopusPoints = FontManager.Add(Font.Name.OctopusPoints, SpriteBatch.Name.HUD, " = 10", Glyph.Name.Consolas36pt, 625.0f, 250.0f);
            pOctopusPoints.SetColor(1.0f, 1.0f, 1.0f);
        }
    }
}
