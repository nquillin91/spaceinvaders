using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Fonts;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Scenes
{
    public abstract class Scene
    {
        public bool markedForTransition = false;
        public bool markedForGameOver = false;

        protected bool previousKeyWasG = false;
        protected PlayerRoot pShipRoot;
        protected WallGroup pWallGroup;
        protected MissileGroup pMissileGroup;
        protected BombRoot pBombRoot;
        protected GameObject pAlienGrid;
        protected Composite pShieldRoot;
        protected UFORoot pUFORoot;

        public Scene()
        {
            TimerManager.Create(3, 1);
            ProxySpriteManager.Create(10, 1);
            GameObjectManager.Create(3, 1);
            ColPairManager.Create(1, 1);

            LoadSpriteBatches();
        }

        private void LoadSpriteBatches()
        {
            SpriteBatchManager.Add(SpriteBatch.Name.HUD);
            SpriteBatchManager.Add(SpriteBatch.Name.Boxes);
            SpriteBatchManager.Add(SpriteBatch.Name.Aliens);
            SpriteBatchManager.Add(SpriteBatch.Name.Player);
            SpriteBatchManager.Add(SpriteBatch.Name.Shields);
            SpriteBatchManager.Add(SpriteBatch.Name.Explosions);
        }

        public abstract void LoadScene();

        public virtual void Update(float time)
        {
            SoundManager.GetSoundEngine().Update();

            bool currentKeyIsG = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_G);
            if (currentKeyIsG == true && previousKeyWasG == false)
            {
                GameObjectManager.ToggleCollisionBoxes();
            }
            previousKeyWasG = currentKeyIsG;

            TimerManager.Update(time);

            ColPairManager.Process();

            GameObjectManager.Update();

            DelayedObjectManager.Process();

            if (markedForTransition == true)
            {
                this.Destroy();
                this.Transition();
            }

            if (markedForGameOver == true)
            {
                this.Destroy();
                SceneManager.LoadScene(SceneManager.SceneName.GameOver);
            }
        }

        public void Draw()
        {
            SpriteBatchManager.Draw();
        }

        public abstract void Transition();

        public void Destroy()
        {
            this.pShipRoot = null;
            this.pWallGroup = null;
            this.pMissileGroup = null;
            this.pBombRoot = null;
            this.pAlienGrid = null;
            this.pShieldRoot = null;
            this.markedForTransition = false;
            this.markedForGameOver = false;

            SpriteBatchManager.Destroy();
            TimerManager.Destroy();
            ProxySpriteManager.Destroy();
            GameObjectManager.Destroy();
            ColPairManager.Destroy();
            FontManager.Destroy();
        }
    }
}
