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
        private const int LEFT_BOUND = -40;
        private const int RIGHT_BOUND = 1240;
        private const float FALL_VELOCITY = 7;
        private const float JUMP_RANGE = 360;
        private const float JUMP_SPEED = 15;

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
        }

        public Vector2 Position { get; set; }

        public Vector2 Acceleration { get; set; }

        public Rectangle Bounds { get; set; }

        public Dictionary<string, Keys> Controls { get; set; }

        public string State { get; set; }

        public bool IsFacingRight { get; set; }

        public bool IsShooting { get; set; }

        public float JumpHeight { get; set; }

        public void Move()
        {
            this.State = "Idle";

            this.JumpAndFall();

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
                        // TODO: FIX
                        if (this.Position.Y >= 790)
                        {
                            this.JumpHeight = JUMP_RANGE;
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
            if (this.Bounds.Right + this.Acceleration.X < LEFT_BOUND)
            {
                this.Position = new Vector2(RIGHT_BOUND, this.Position.Y);
            }
            else if (this.Position.X + this.Acceleration.X > RIGHT_BOUND)
            {
                this.Position = new Vector2(LEFT_BOUND, this.Position.Y);
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

        private void JumpAndFall()
        {
            if (this.JumpHeight > 0)
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y - JUMP_SPEED);
                this.JumpHeight -= JUMP_SPEED;
            }

            if (this.Position.Y + FALL_VELOCITY < 800)
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + FALL_VELOCITY);
            }
        }
    }
}
