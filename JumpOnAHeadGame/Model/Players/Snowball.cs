namespace JumpOnAHeadGame.Model.Players
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Snowball
    {
        private const int LEFT_BOUND = -40;
        private const int RIGHT_BOUND = 1240;
        private const float FALL_VELOCITY = 0.8f;
        private const float BALL_SPEED = 16;

        public Snowball(Vector2 position, Sprite sprite, bool isGoingRight)
        {
            this.Position = position;
            this.Sprite = sprite;
            this.IsMelting = false;
            this.IsGoingRight = isGoingRight;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }

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
                this.IsMelting = true;
            }
        }

        public void ActOnPlayer(Player player)
        {
            if (this.Bounds.Intersects(player.Bounds))
            {
                SoundManager.Play("SnowballHit", false);
                this.IsMelting = true;
                player.Health -= 10;
            }
        }

        public void ActOnBlock(Block block)
        {
            if (this.Bounds.Intersects(block.Bounds))
            {
                this.IsMelting = true;
            }
        }
    }
}
