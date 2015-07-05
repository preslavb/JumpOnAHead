namespace JumpOnAHeadGame.Model.Players
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller.Managers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        private const float FRICTION_FORCE = 0.1f;
        private const float MAX_PLAYER_SPEED = 10;
        private const float PLAYER_ACCELERATION = 0.1f;
        private const int LEFT_BOUND = 0;
        private const int RIGHT_BOUND = 1280;
        private const float FALL_VELOCITY = 7;
        private const float JUMP_RANGE = 400;
        private const float JUMP_SPEED = 18;

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Keys dash, Vector2 position)
        {
            this.State = "Idle";
            this.IsFacingRight = true;
            this.JumpHeight = 0;
            this.Controls = new Dictionary<string, Keys>();
            this.Controls.Add("Move Left", moveLeft);
            this.Controls.Add("Move Right", moveRight);
            this.Controls.Add("Jump", jump);
            this.Controls.Add("Dash", dash);
            this.Position = position;
            this.Health = 300;
        }

        public Vector2 Position { get; set; }

        public Vector2 Acceleration { get; set; }

        public Rectangle Bounds { get; set; }

        public Dictionary<string, Keys> Controls { get; set; }

        public string State { get; set; }

        public bool IsFacingRight { get; set; }

        public bool IsShooting { get; set; }

        public float JumpHeight { get; set; }

        public int Health { get; set; }

        public void Move(List<Block> blocks)
        {
            this.State = "Idle";

            // Jumping
            if (this.JumpHeight > 0)
            {
                this.JumpHeight -= JUMP_SPEED;
                this.Position = new Vector2(this.Position.X, this.Position.Y - JUMP_SPEED);
                foreach (var block in blocks)
                {
                    if (this.Bounds.Intersects(block.Bounds) && this.Bounds.Top <= block.Bounds.Bottom)
                    {
                        this.JumpHeight = 0;
                    }
                }
            }

            // Falling
            float fall_velocity = FALL_VELOCITY;
            foreach (var block in blocks)
            {
                if (this.Bounds.Intersects(block.Bounds) && this.Bounds.Top <= block.Bounds.Top && this.Bounds.Bottom >= block.Bounds.Top && this.Bounds.Top <= block.Bounds.Bottom && this.Bounds.Bottom <= block.Bounds.Bottom)
                {
                    fall_velocity = 0;
                }
            }

            this.Position = new Vector2(this.Position.X, this.Position.Y + fall_velocity);

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
                            foreach (var block in blocks)
                            {
                                if (this.Bounds.Intersects(block.Bounds) && 
                                    this.Bounds.Left >= block.Bounds.Left && 
                                    this.Bounds.Left <= block.Bounds.Right && 
                                    this.Bounds.Right >= block.Bounds.Right && 
                                    this.Bounds.Right >= block.Bounds.Left && 
                                    this.Bounds.Bottom >= block.Bounds.Bottom)
                                {
                                    this.Acceleration = new Vector2(0, this.Acceleration.Y);
                                }
                            }
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
                            foreach (var block in blocks)
                            {
                                if (this.Bounds.Intersects(block.Bounds) && 
                                    this.Bounds.Left <= block.Bounds.Left && 
                                    this.Bounds.Left <= block.Bounds.Right && 
                                    this.Bounds.Right <= block.Bounds.Right && 
                                    this.Bounds.Right >= block.Bounds.Left && 
                                    this.Bounds.Bottom >= block.Bounds.Bottom)
                                {
                                    this.Acceleration = new Vector2(0, this.Acceleration.Y);
                                }
                            }
                        }
                    }

                    if (key.Button == this.Controls["Jump"] && key.ButtonState == KeyboardButtonState.KeyState.Held)
                    {
                        foreach (var block in blocks)
                        {
                            if (this.Position.Y + FALL_VELOCITY > 800 || (this.Bounds.Intersects(block.Bounds) && this.Bounds.Top <= block.Bounds.Top && this.Bounds.Bottom >= block.Bounds.Top && this.Bounds.Top <= block.Bounds.Bottom && this.Bounds.Bottom <= block.Bounds.Bottom))
                            {
                                this.JumpHeight = JUMP_RANGE;
                            }
                        }

                        this.FixAcceleration();
                    }

                    if (key.Button == this.Controls["Dash"] && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.IsShooting = true;
                        this.FixAcceleration();
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
