using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
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
    class Round1Scene : Scene
    {
        public override void LoadScene()
        {
            AlienManager.Create();

            LoadWalls();

            LoadMissiles();
            LoadBombs();

            LoadPlayer();

            AddAnimations();

            BuildAlienGrid();
            LoadUFORoot();

            BuildSheilds();

            AddColPairs();

            HUDManager.Setup();
        }

        public override void Update(float time)
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE))
            {
                PlayerShip pShip = PlayerManager.GetShip();
                pShip.ShootMissile();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT))
            {
                PlayerShip pShip = PlayerManager.GetShip();
                pShip.MoveLeft();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT))
            {
                PlayerShip pShip = PlayerManager.GetShip();
                pShip.MoveRight();
            }

            base.Update(time);
        }

        public override void Transition()
        {
            SceneManager.LoadScene(SceneManager.SceneName.Round2);
        }

        private void LoadPlayer()
        {
            this.pShipRoot = new PlayerRoot(GameObject.Name.PlayerRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(this.pShipRoot);

            PlayerManager.Create();
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

        private void LoadMissiles()
        {
            this.pMissileGroup = new MissileGroup(GameObject.Name.MissileGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            this.pMissileGroup.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Aliens));
            this.pMissileGroup.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));

            GameObjectManager.Attach(this.pMissileGroup);
        }

        private void LoadBombs()
        {
            this.pBombRoot = new BombRoot(GameObject.Name.BombRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(this.pBombRoot);
        }

        private void AddAnimations()
        {
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
            TimerManager.Add(TimerEvent.Name.AliensMove, new AlienMoveHorizontallyCommand(), 0.5f);
        }

        private void BuildAlienGrid()
        {
            AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
            this.pAlienGrid = AlienManager.GetAlienGrid();

            for (int i = 0; i < 11; i++)
            {
                GameObject pGameObj;
                GameObject pCol = alienFactory.Create(GameObject.Name.AlienColumn, AlienCategory.Type.Column);

                pGameObj = alienFactory.Create(GameObject.Name.Squid, AlienCategory.Type.Squid, (64.0f + i * 64.0f), 600.0f);
                pCol.Add(pGameObj);

                pGameObj = alienFactory.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, (64.0f + i * 64.0f), 565.0f);
                pCol.Add(pGameObj);

                pGameObj = alienFactory.Create(GameObject.Name.Crab, AlienCategory.Type.Crab, (64.0f + i * 64.0f), 530.0f);
                pCol.Add(pGameObj);

                pGameObj = alienFactory.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, (64.0f + i * 64.0f), 495.0f);
                pCol.Add(pGameObj);

                pGameObj = alienFactory.Create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, (64.0f + i * 64.0f), 460.0f);
                pCol.Add(pGameObj);

                this.pAlienGrid.Add(pCol);
            }

            GameObjectManager.Attach(this.pAlienGrid);
        }

        private void LoadUFORoot()
        {
            this.pUFORoot = new UFORoot(GameObject.Name.UFORoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(this.pUFORoot);
        }

        public void BuildSheilds()
        {
            this.pShieldRoot = (Composite)new ShieldRoot(GameObject.Name.ShieldRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectManager.Attach(this.pShieldRoot);

            this.BuildShield(50.0f, 175.0f);
            this.BuildShield(350.0f, 175.0f);
            this.BuildShield(650.0f, 175.0f);
            this.BuildShield(950.0f, 175.0f);
        }

        private void BuildShield(float start_x, float start_y)
        {
            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, this.pShieldRoot);
            {
                int j = 0;

                GameObject pColumn;

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                float off_x = 0;
                float brickWidth = 20.0f;
                float brickHeight = 10.0f;

                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

                SF.SetParent(this.pShieldRoot);
                pColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                SF.SetParent(pColumn);

                off_x += brickWidth;
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
                SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
                SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
                SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);
            }
        }

        private void AddColPairs()
        {
            // Associate in a collision pair
            ColPair pColPair;
            pColPair = ColPairManager.Add(ColPair.Name.Missile, this.pMissileGroup, this.pAlienGrid);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveAlienObserver());
            pColPair.Attach(new AlienExplosionObserver());
            pColPair.Attach(new PlayerMissileStateChangeObserver());

            pColPair = ColPairManager.Add(ColPair.Name.MissileWall, this.pMissileGroup, this.pWallGroup);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new MissileExplosionObserver());
            pColPair.Attach(new PlayerMissileStateChangeObserver());

            pColPair = ColPairManager.Add(ColPair.Name.AlienWall, this.pAlienGrid, this.pWallGroup);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new MoveAliensDownObserver());

            pColPair = ColPairManager.Add(ColPair.Name.UFOWall, this.pWallGroup, this.pUFORoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveUFOObserver());
            
            pColPair = ColPairManager.Add(ColPair.Name.UFOMissile, this.pMissileGroup, this.pUFORoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveUFOObserver());
            pColPair.Attach(new UFOExplosionObserver());
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new PlayerMissileStateChangeObserver());

            pColPair = ColPairManager.Add(ColPair.Name.PlayerWall, this.pShipRoot, this.pWallGroup);
            Debug.Assert(pColPair != null);

            pColPair = ColPairManager.Add(ColPair.Name.MissileShield, this.pMissileGroup, this.pShieldRoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveShieldObserver());
            pColPair.Attach(new PlayerMissileStateChangeObserver());

            pColPair = ColPairManager.Add(ColPair.Name.AlienShield, this.pAlienGrid, this.pShieldRoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveShieldObserver());


            pColPair = ColPairManager.Add(ColPair.Name.BombMissile, this.pMissileGroup, this.pBombRoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new BombMissileCollision());
            pColPair.Attach(new PlayerMissileStateChangeObserver());

            pColPair = ColPairManager.Add(ColPair.Name.BombShield, this.pBombRoot, this.pShieldRoot);
            Debug.Assert(pColPair != null);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveShieldObserver());

            pColPair = ColPairManager.Add(ColPair.Name.BombWall, this.pBombRoot, this.pWallGroup);
            pColPair.Attach(new RemoveBombObserver());

            pColPair = ColPairManager.Add(ColPair.Name.BombPlayer, this.pBombRoot, this.pShipRoot);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemovePlayerObserver());
            pColPair.Attach(new PlayerExplosionObserver());
        }
    }
}
