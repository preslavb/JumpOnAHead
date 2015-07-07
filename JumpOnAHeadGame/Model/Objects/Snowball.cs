namespace JumpOnAHeadGame.Model.Objects
{
    using JumpOnAHeadGame.Controller.Managers;
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class Snowball : GameObject
    {
        private const int LEFT_BOUND = -40;
        private const int RIGHT_BOUND = 1240;
        private const float FALL_VELOCITY = 0.8f;
        private const float BALL_SPEED = 16;

        public Snowball(Vector2 position, Sprite sprite, bool isGoingRight)
            : base(position, sprite)
        {
            this.IsMelting = false;
            this.IsGoingRight = isGoingRight;
        }

        public bool IsMelting { get; set; }

        public bool IsGoingRight { get; set; }

        public void Move()
        {
            float ballSpeed;
            if (this.IsGoingRight)
            {
                ballSpeed = BALL_SPEED;
            }
            else
            {
                ballSpeed = -BALL_SPEED;
            }

            if (this.Position.Y + FALL_VELOCITY < 900)
            {
                if ((this.Bounds.Left + (this.Bounds.Width / 2)) + ballSpeed < LEFT_BOUND)
                {
                    this.Position = new Vector2(RIGHT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
                }
                else if ((this.Bounds.Right - (this.Bounds.Width / 2)) + ballSpeed > RIGHT_BOUND)
                {
                    this.Position = new Vector2(LEFT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
                }
                else
                {
                    this.Position = new Vector2(this.Position.X + ballSpeed, this.Position.Y);
                }

                this.Position = new Vector2(this.Position.X, this.Position.Y + FALL_VELOCITY);
            }
            else
            {
                SoundManager.Play("SnowballHit");
                this.IsMelting = true;
            }
        }

        public override void ActOnPlayer(List<Player> players)
        {
            foreach (var player in players)
            {
                if (this.Bounds.Intersects(player.Bounds))
                {
                    SoundManager.Play("SnowballHit");
                    this.IsMelting = true;
                    player.Health -= 10;
                }
            }
        }

        public void ActOnBlock(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                if (gameObject.GetType() == typeof(Block))
                {
                    if (this.Bounds.Intersects(gameObject.Bounds))
                    {
                        SoundManager.Play("SnowballHitBlock");
                        this.IsMelting = true;
                    }
                }
            }
        }
    }
}
