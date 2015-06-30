namespace JumpOnAHeadGame.Model.Players
{
    using JumpOnAHeadGame.Controller.Managers;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;

    public class Player
    {
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public Dictionary<string, Keys> Controls { get; set; }
        public string State { get; set; }

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Keys dash, Vector2 position)
        {
            this.FacingRight = true;
            this.State = "Idle";
            this.Controls = new Dictionary<string, Keys>();
            Controls.Add("Move Left", moveLeft);
            Controls.Add("Move Right", moveRight);
            Controls.Add("Jump", jump);
            Controls.Add("Dash", dash);
            this.Position = position;
        }

        public bool FacingRight { get; set; }

        public void Move()
        {
            this.State = "Idle";
            foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
            {
                if (Key.Button == this.Controls["Move Left"] && Key.ButtonState == KeyboardButtonState.KeyState.Held)
                {
                    this.FacingRight = false;
                    if (this.Position.X < 0)
                    {
                        this.Position = new Vector2(0, Position.Y);
                    }
                    else
                    {
                        this.Position += new Vector2(-10, 0);
                    }
                    this.State = "Running";
                }
                if (Key.Button == this.Controls["Move Right"] && Key.ButtonState == KeyboardButtonState.KeyState.Held)
                {
                    this.FacingRight = true;
                    if (this.Position.X > 1200)
                    {
                        this.Position = new Vector2(1200, Position.Y);
                    }
                    else
                    {
                        this.Position += new Vector2(10, 0);
                    }
                    this.State = "Walking";
                }
                if (Key.Button == this.Controls["Jump"] && Key.ButtonState == KeyboardButtonState.KeyState.Held)
                {
                    // TODO
                }
                if (Key.Button == this.Controls["Dash"] && Key.ButtonState == KeyboardButtonState.KeyState.Held)
                {
                    // TODO
                }
            }
        }
    }
}
