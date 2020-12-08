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
    class GameOver : Scene
    {
        public override void LoadScene()
        {
            AlienManager.Create();

            LoadWalls();
            LoadText();

            HUDManager.Setup();
        }

        public override void Update(float time)
        {
            base.Update(time);

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE))
            {
                this.markedForTransition = true;
            }
        }

        public override void Transition()
        {
            SceneManager.LoadScene(SceneManager.SceneName.SelectScreen);
        }

        private void LoadWalls()
        {
            this.pWallGroup = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Aliens));

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, GameSprite.Name.Wall, 600, 700, 1200, 100);
            pWallTop.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, GameSprite.Name.Wall, 600, 25, 1200, 50);
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

        private void LoadText()
        {
            Font pPlayText = FontManager.Add(Font.Name.Play, SpriteBatch.Name.HUD, "GAME OVER!", Glyph.Name.Consolas36pt, 525.0f, 550.0f);
            pPlayText.SetColor(1.0f, 1.0f, 1.0f);

            Font pSpaceText = FontManager.Add(Font.Name.Space, SpriteBatch.Name.HUD, "Press Space to go back to the select screen", Glyph.Name.Consolas36pt, 200.0f, 350.0f);
            pSpaceText.SetColor(1.0f, 1.0f, 1.0f);
        }
    }
}
