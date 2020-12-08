using SpaceInvaders.Aliens;
using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Images;
using SpaceInvaders.Player;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Observers
{
    class RemovePlayerObserver : ColObserver
    {
        private GameObject pShip;

        public RemovePlayerObserver()
        {
            this.pShip = null;
        }

        public RemovePlayerObserver(RemovePlayerObserver p)
        {
            this.pShip = p.pShip;
        }

        public override void Notify()
        {
            AlienManager.GetAlienGrid().ToggleHaltMovement();

            this.pShip = (PlayerShip)this.pSubject.pObjB;
            Debug.Assert(this.pShip != null);

            if (this.pShip.bMarkForDeath == false)
            {
                this.pShip.bMarkForDeath = true;
                ((PlayerShip)this.pShip).SetPlayerState(PlayerManager.State.Dead);

                RemovePlayerObserver pObserver = new RemovePlayerObserver(this);
                DelayedObjectManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            SpriteNode pSpriteNode = this.pShip.pProxySprite.GetSpriteNode();
            Debug.Assert(pSpriteNode != null);

            SpriteBatchManager.Remove(pSpriteNode);

            GameObjectManager.Find(GameObject.Name.PlayerRoot).Remove(this.pShip);
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}