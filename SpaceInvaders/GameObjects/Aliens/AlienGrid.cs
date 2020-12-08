using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.States.Alien;
using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    public class AlienGrid : Composite
    {
        private static readonly Random pRandom = new Random();

        private GameObject pUFO;

        private AlienGridVerticalState poVerticalState;
        private AlienGridHorizontalState poHorizontalState;

        public float marchingIterationCount = 0;
        public float marchIterationSetSpeed = 50;
        private int musicNoteCount = 0;

        private bool haltMovement = false;

        public AlienGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        public void SetVerticalState(AlienManager.State inState)
        {
            this.poVerticalState = AlienManager.GetState(inState);
        }

        public void SetHorizontalState(AlienManager.HorizontalState inState)
        {
            this.poHorizontalState = AlienManager.GetHorizontalState(inState);
        }

        private void Move()
        {
            this.poVerticalState.MoveVertically(this);
            this.poHorizontalState.MoveHorizontally(this);
        }

        private void AttemptToFireBombs()
        {
            ForwardIterator iterator = new ForwardIterator(this);

            Component pNode = iterator.First();
            while (!iterator.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;

                if (pGameObj.name == GameObject.Name.AlienColumn)
                {
                    AlienColumn pAlienColumn = (AlienColumn)pGameObj;
                    int value = pRandom.Next(0, 1000);

                    if (value >= 997)
                    {
                        GameObject pLastAlien = (pAlienColumn).GetLastAlien();

                        // If pLastAlien is null then the column is empty
                        if (pLastAlien != null && pAlienColumn.pBomb == null)
                        {
                            BombFactory pBombFactory = new BombFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
                            pAlienColumn.pBomb = (Bomb)pBombFactory.Create(pLastAlien.x, pLastAlien.y - 20.0f);
                            pAlienColumn.pBomb.SetAlienColumn(pAlienColumn);
                        }
                    }
                }

                pNode = iterator.Next();
            }
        }

        private void CheckForUFO()
        {
            int value = pRandom.Next(0, 5000);

            if (AlienManager.IsUFOInPlay() != true)
            {
                //4995
                if (value > 4995)
                {
                    // 50 x when coming from left
                    // 1150 x when coming from right
                    float startingXPosition = (AlienManager.GetUFODirection() == 1.0 ? 50.0f : 1150.0f);

                    this.pUFO = new UFO(GameObject.Name.UFO, GameSprite.Name.UFO, startingXPosition, 625);
                    pUFO.ActivateCollisionSprite(SpriteBatchManager.Find(SpriteBatch.Name.Boxes));
                    pUFO.ActivateGameSprite(SpriteBatchManager.Find(SpriteBatch.Name.Aliens));

                    // Attach the missile to the Bomb root
                    GameObject pUFORoot = GameObjectManager.Find(GameObject.Name.UFORoot);
                    Debug.Assert(pUFORoot != null);
                    pUFORoot.Add(pUFO);

                    AlienManager.SetIsUFOInPlay(true);
                }
            } else
            {
                this.pUFO.x += AlienManager.GetUFOSpeed() * AlienManager.GetUFODirection();
            }
        }

        private void PlaySound()
        {
            if (marchingIterationCount > marchIterationSetSpeed)
            {
                switch (musicNoteCount)
                {
                    case 0:
                        SoundManager.Find(AudioSource.Name.Alien_1).Play();
                        musicNoteCount++;
                        break;
                    case 1:
                        SoundManager.Find(AudioSource.Name.Alien_2).Play();
                        musicNoteCount++;
                        break;
                    case 2:
                        SoundManager.Find(AudioSource.Name.Alien_3).Play();
                        musicNoteCount++;
                        break;
                    case 3:
                        SoundManager.Find(AudioSource.Name.Alien_4).Play();
                        musicNoteCount = 0;
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }

                marchingIterationCount = 0;
            }

            marchingIterationCount++;
        }

        public void ToggleHaltMovement()
        {
            this.haltMovement = (this.haltMovement ? false : true);
        }

        public bool GetHaltMovement()
        {
            return this.haltMovement;
        }

        public override void Update()
        {
            if (!this.haltMovement)
            {
                this.PlaySound();

                this.Move();

                this.AttemptToFireBombs();

                this.CheckForUFO();
            }

            base.BaseUpdateBoundingBox(this);

            base.Update();
        }

        public override void Remove()
        {
            // Make sure we take care of the UFO
            if (AlienManager.IsUFOInPlay())
            {
                this.pUFO.GetColObject().poColRect.Set(0, 0, 0, 0);
                this.pUFO.Update();

                GameObject pParent = (GameObject)this.pUFO.pParent;
                pParent.Update();

                this.pUFO.Remove();

                AlienManager.SetIsUFOInPlay(false);
                AlienManager.ToggleUFODirection();
            }

            GameObjectManager pMan = GameObjectManager.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(this.pProxySprite != null);
            SpriteNode pSpriteNode = this.pProxySprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteBatchManager.Remove(pSpriteNode);

            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            pSpriteNode = this.poColObj.pColSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteBatchManager.Remove(pSpriteNode);
        }

        public override void Accept(ColVisitor other)
        {
            // Call the appropriate collision reaction            
            other.VisitAlienGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitWallGroup(WallGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }
    }
}
