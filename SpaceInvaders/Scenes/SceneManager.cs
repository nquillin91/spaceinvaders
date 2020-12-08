using SpaceInvaders.Batches;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.States;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Scenes
{
    public class SceneManager
    {
        private static SceneManager poSceneManagerInstance;
        private Scene pCurrentScene;
        private SelectScreen pSelectScreen;
        private Round1Scene pRound1Scene;
        private Round2Scene pRound2Scene;

        public enum SceneName
        {
            SelectScreen,
            Round1,
            Round2,
            GameOver
        }

        private SceneManager()
        {
        }

        public static void Create()
        {
            Debug.Assert(poSceneManagerInstance == null);

            if (poSceneManagerInstance == null)
            {
                poSceneManagerInstance = new SceneManager();
            }

            Debug.Assert(poSceneManagerInstance != null);
        }

        public static void LoadScene(SceneName name)
        {
            SceneManager sceneMan = SceneManager.GetInstance();
            Debug.Assert(sceneMan != null);

            switch (name)
            {
                case SceneName.SelectScreen:
                    sceneMan.pCurrentScene = new SelectScreen();
                    break;
                case SceneName.Round1:
                    sceneMan.pCurrentScene = new Round1Scene();
                    break;
                case SceneName.Round2:
                    sceneMan.pCurrentScene = new Round2Scene();
                    break;
                case SceneName.GameOver:
                    sceneMan.pCurrentScene = new GameOver();
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            sceneMan.pCurrentScene.LoadScene();
        }

        public static void Draw()
        {
            SceneManager sceneMan = SceneManager.GetInstance();
            Debug.Assert(sceneMan != null);

            sceneMan.pCurrentScene.Draw();
        }

        public static void MarkForTransition()
        {
            SceneManager sceneMan = SceneManager.GetInstance();
            Debug.Assert(sceneMan != null);
            Debug.Assert(sceneMan.pCurrentScene != null);

            sceneMan.pCurrentScene.markedForTransition = true;
        }

        public static void MarkForGameOver()
        {
            SceneManager sceneMan = SceneManager.GetInstance();
            Debug.Assert(sceneMan != null);
            Debug.Assert(sceneMan.pCurrentScene != null);

            sceneMan.pCurrentScene.markedForGameOver = true;
        }

        public static void Update(float time)
        {
            SceneManager sceneMan = SceneManager.GetInstance();
            Debug.Assert(sceneMan != null);
            Debug.Assert(sceneMan.pCurrentScene != null);

            sceneMan.pCurrentScene.Update(time);
        }

        private static SceneManager GetInstance()
        {
            Debug.Assert(poSceneManagerInstance != null);

            return poSceneManagerInstance;
        }
    }
}