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

        public PlayerShip(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
         : base(name, spriteName, PlayerCategory.Type.Player)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 3.0f;
            this.state = null;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitPlayerShip(this);
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
            this.state.Shoot(this);
        }

        public void SetState(PlayerManager.State inState)
        {
            this.state = PlayerManager.GetState(inState);
        }

        public void Handle()
        {
            this.state.Handle(this);
        }

        public PlayerState GetState()
        {
            return this.state;
        }
    }
}