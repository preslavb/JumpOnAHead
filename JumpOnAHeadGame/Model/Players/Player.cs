namespace JumpOnAHeadGame.Model.Players
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model.Objects;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        private const float FRICTION_FORCE = 0.08f;
        private const float MAX_PLAYER_SPEED = 8;
        private const float PLAYER_ACCELERATION = 0.1f;
        private const int LEFT_BOUND = 0;
        private const int RIGHT_BOUND = 1280;
        private const float FALL_VELOCITY = 6;
        private const float JUMP_RANGE = 400;
        private const float JUMP_SPEED = 16;

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Keys dash, Vector2 position, Animation animation, bool isFacingRight)
        {
            this.State = "Idle";
            this.IsFacingRight = isFacingRight;
            this.JumpHeight = 0;
            this.Controls = new Dictionary<string, Keys>();
            this.Controls.Add("Move Left", moveLeft);
            this.Controls.Add("Move Right", moveRight);
            this.Controls.Add("Jump", jump);
            this.Controls.Add("Dash", dash);
            this.Position = position;
            this.Health = 100;
            this.Snowballs = 5;
            this.IsGrounded = false;
            this.PlayerAnimation = animation;
        }

        public Animation PlayerAnimation { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 Acceleration { get; set; }

        public Rectangle Bounds { get; set; }

        public Dictionary<string, Keys> Controls { get; set; }

        public string State { get; set; }

        public bool IsFacingRight { get; set; }

        public bool IsShooting { get; set; }

        public bool IsGrounded { get; set; }

        public float JumpHeight { get; set; }

        public int Health { get; set; }

        public int Snowballs { get; set; }

        public void Move(List<GameObject> gameObjects)
        {
            this.State = "Idle";

            // Jumping
            if (this.JumpHeight > 0)
            {
                foreach (var block in gameObjects)
                {
                    if (block.GetType() == typeof(Block))
                    {
                        Rectangle tempRect = new Rectangle((int)this.Bounds.X, (int)((this.Bounds.Y + FALL_VELOCITY) - JUMP_SPEED), this.Bounds.Width, this.Bounds.Height);
                        if (tempRect.Intersects(block.Bounds))
                        {
                            this.JumpHeight = 0;
                        }
                    }
                }

                if (this.JumpHeight != 0)
                {
                    this.Position = new Vector2(this.Position.X, this.Position.Y - JUMP_SPEED);
                    this.JumpHeight -= JUMP_SPEED;
                }
            }

            // Falling
            this.IsGrounded = false;
            foreach (var block in gameObjects)
            {
                if (block.GetType() == typeof(Block))
                {
                    Rectangle tempRect = new Rectangle((int)this.Bounds.X, (int)(this.Bounds.Y + FALL_VELOCITY), this.Bounds.Width, this.Bounds.Height);
                    if (tempRect.Intersects(block.Bounds))
                    {
                        this.IsGrounded = true;
                    }
                }
            }

            if (!this.IsGrounded)
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + FALL_VELOCITY);
            }

            // Moving
            if (Keyboard.GetState().IsKeyDown(this.Controls["Move Left"]) || Keyboard.GetState().IsKeyDown(this.Controls["Move Right"]) || Keyboard.GetState().IsKeyDown(this.Controls["Jump"]) || Keyboard.GetState().IsKeyDown(this.Controls["Dash"]))
            {
                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if (key.Button == this.Controls["Move Left"] && key.ButtonState == KeyboardButtonState.KeyState.Held)
                    {
                        if (!Keyboard.GetState().IsKeyDown(this.Controls["Move Right"]))
                        {
                            this.IsFacingRight = false;
                        }

                        this.State = "Running";
                        if (this.Acceleration.X > -MAX_PLAYER_SPEED)
                        {
                            this.Acceleration = new Vector2(this.Acceleration.X - PLAYER_ACCELERATION, this.Acceleration.Y);
                        }
                    }

                    if (key.Button == this.Controls["Move Right"] && key.ButtonState == KeyboardButtonState.KeyState.Held)
                    {
                        if (!Keyboard.GetState().IsKeyDown(this.Controls["Move Left"]))
                        {
                            this.IsFacingRight = true;
                        }

                        this.State = "Running";
                        if (this.Acceleration.X < MAX_PLAYER_SPEED)
                        {
                            this.Acceleration = new Vector2(this.Acceleration.X + PLAYER_ACCELERATION, this.Acceleration.Y);
                        }
                    }

                    if (key.Button == this.Controls["Jump"] && key.ButtonState == KeyboardButtonState.KeyState.Held)
                    {
                        foreach (var block in gameObjects)
                        {
                            if (this.IsGrounded)
                            {
                                this.IsGrounded = false;
                                this.JumpHeight = JUMP_RANGE;
                            }
                        }

                        if (!Keyboard.GetState().IsKeyDown(this.Controls["Move Left"]) && !Keyboard.GetState().IsKeyDown(this.Controls["Move Right"]))
                        {
                            this.FixAcceleration();
                        }
                    }

                    if (key.Button == this.Controls["Dash"] && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        if (this.Snowballs != 0)
                        {
                            this.IsShooting = true;
                            this.Snowballs--;
                        }
                    }

                    if (key.Button == this.Controls["Dash"] && key.ButtonState == KeyboardButtonState.KeyState.Held)
                    {
                        if (!Keyboard.GetState().IsKeyDown(this.Controls["Move Left"]) && !Keyboard.GetState().IsKeyDown(this.Controls["Move Right"]))
                        {
                            this.FixAcceleration();
                        }
                    }
                }
            }
            else
            {
                this.FixAcceleration();
            }

            // Should do a check for collision
            if ((this.Bounds.Left + (this.Bounds.Width / 2)) + this.Acceleration.X < LEFT_BOUND)
            {
                this.Position = new Vector2(RIGHT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
            }
            else if ((this.Bounds.Right - (this.Bounds.Width / 2)) + this.Acceleration.X > RIGHT_BOUND)
            {
                this.Position = new Vector2(LEFT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
            }
            else
            {
                int tempDistance = this.Acceleration.X > 0 ? 1 : -1; // hack
                Rectangle tempRect = new Rectangle((int)(this.Bounds.X + (this.Acceleration.X + tempDistance)), (int)this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
                foreach (var block in gameObjects)
                {
                    if (block.GetType() == typeof(Block))
                    {
                        if (tempRect.Intersects(block.Bounds))
                        {
                            this.Acceleration = new Vector2(0, 0);
                        }
                    }
                }

                this.Position += this.Acceleration;
            }
        }

        private void FixAcceleration()
        {
            if (this.Acceleration.X > FRICTION_FORCE)
            {
                this.Acceleration = new Vector2(this.Acceleration.X - FRICTION_FORCE, this.Acceleration.Y);
                this.State = "Walking";
            }
            else if (this.Acceleration.X < -FRICTION_FORCE)
            {
                this.Acceleration = new Vector2(this.Acceleration.X + FRICTION_FORCE, this.Acceleration.Y);
                this.State = "Walking";
            }
            else
            {
                this.Acceleration = new Vector2(0, this.Acceleration.Y);
            }
        }
    }
}
