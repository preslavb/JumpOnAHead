namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class UpdateState : State
    {
        public UpdateState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            this.SpritesInState.Add(UIInitializer.LevelBackground.Sprite);

            this.SpritesInState.Add(UIInitializer.PlayerUI1.PlayerAnimation);
            this.SpritesInState.Add(UIInitializer.PlayerUI2.PlayerAnimation);
        }

        private bool IsDone { get; set; }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                if (StateMachine.CurrentLevel.Player1.IsShooting)
                {
                    StateMachine.CurrentLevel.Player1.IsShooting = false;
                    Snowball newSnowball = new Snowball(StateMachine.CurrentLevel.Player1.Position, UIInitializer.CreateTile("Snowball", StateMachine.CurrentLevel.Player1.Position, 1f).Sprite, StateMachine.CurrentLevel.Player1.IsFacingRight);
                    StateMachine.CurrentLevel.ListOfSnowballs.Add(newSnowball);
                    this.SpritesInState.Add(newSnowball.Sprite);
                }

                //StateMachine.CurrentLevel.Player1.Move();
                UIInitializer.PlayerUI1.PlayerAnimation.Position = StateMachine.CurrentLevel.Player1.Position;
                UIInitializer.PlayerUI1.PlayerAnimation.IsFacingRight = StateMachine.CurrentLevel.Player1.IsFacingRight;
                StateMachine.CurrentLevel.Player1.Bounds = new Rectangle((int)StateMachine.CurrentLevel.Player1.Position.X, (int)StateMachine.CurrentLevel.Player1.Position.Y, UIInitializer.PlayerUI1.PlayerAnimation.SourceRectangle.Width, UIInitializer.PlayerUI1.PlayerAnimation.SourceRectangle.Height);
                UIInitializer.PlayerUI1.PlayerAnimation.ChangeAnimation(StateMachine.CurrentLevel.Player1.State);

                StateMachine.CurrentLevel.Player2.Move();
                UIInitializer.PlayerUI2.PlayerAnimation.Position = StateMachine.CurrentLevel.Player2.Position;
                UIInitializer.PlayerUI2.PlayerAnimation.IsFacingRight = StateMachine.CurrentLevel.Player2.IsFacingRight;
                StateMachine.CurrentLevel.Player2.Bounds = new Rectangle((int)StateMachine.CurrentLevel.Player2.Position.X, (int)StateMachine.CurrentLevel.Player2.Position.Y, UIInitializer.PlayerUI2.PlayerAnimation.SourceRectangle.Width, UIInitializer.PlayerUI2.PlayerAnimation.SourceRectangle.Height);
                UIInitializer.PlayerUI2.PlayerAnimation.ChangeAnimation(StateMachine.CurrentLevel.Player2.State);
                UIInitializer.PlayerUI2.PlayerAnimation.Tint = Color.Aquamarine;

                for (int i = 0; i < StateMachine.CurrentLevel.ListOfSnowballs.Count; i++)
                {
                    if (!StateMachine.CurrentLevel.ListOfSnowballs[i].IsMelting)
                    {
                        StateMachine.CurrentLevel.ListOfSnowballs[i].Move();
                        StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite.Position = StateMachine.CurrentLevel.ListOfSnowballs[i].Position;
                    }
                    else
                    {
                        this.SpritesInState.Remove(StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite);
                        StateMachine.CurrentLevel.ListOfSnowballs.Remove(StateMachine.CurrentLevel.ListOfSnowballs[i]);
                    }
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
            //// foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
            // {
            //     if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
            //     {
            //        Globals.Graphics.GraphicsDevice.Clear(Color.Red);
            //     }
            //     else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Held)
            //     {
            //         Globals.Graphics.GraphicsDevice.Clear(Color.Yellow);
            //     }
            //     else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Released)
            //     {
            //         Globals.Graphics.GraphicsDevice.Clear(Color.Green);
            //     }    
            // }
            foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
            {
                if (key.Button == Keys.P && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                {
                    this.IsDone = !this.IsDone;
                }

                if (key.Button == Keys.Escape && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                {
                    this.IsDone = !this.IsDone;
                    this.NextState = new MenuState(this);
                }
            }
        }
    }
}
