using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sprites;
using SpaceInvaders.States;
using System;
using System.Diagnostics;


namespace SpaceInvaders.Player
{
    public class PlayerShip : PlayerCategory
    {
        public float shipSpeed;
        private PlayerState state;
        private PlayerMissileState missileState;

        public PlayerShip(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
         : base(name, spriteName, PlayerCategory.Type.Player)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 3.0f;
            this.state = null;
            this.missileState = null;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitPlayerShip(this);
        }

        public override void VisitBomb(Bomb b)
        {
            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public void MoveRight()
        {
            this.state.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.state.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.missileState.Shoot(this);
        }

        public void SetPlayerState(PlayerManager.State inState)
        {
            this.state = PlayerManager.GetState(inState);
        }

        public void SetMissileState(PlayerManager.MissileState inState)
        {
            this.missileState = PlayerManager.GetMissileState(inState);
        }

        public void HandlePlayerState()
        {
            this.state.Handle(this);
        }

        public void HandleMissileState()
        {
            this.missileState.Handle(this);
        }

        public PlayerState GetState()
        {
            return this.state;
        }

        public PlayerMissileState GetMissileState()
        {
            return this.missileState;
        }
    }
}