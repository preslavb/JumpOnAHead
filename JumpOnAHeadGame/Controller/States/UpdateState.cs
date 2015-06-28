namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    public class UpdateState : State
    {
        private bool IsDone { get; set; }
        public UpdateState(State nextState)
            :base(nextState)
        {
            this.NextState = nextState;
            this.SpritesInState.Add(UIInitializer.PlayerUI1.PlayerAnimation);
            this.SpritesInState.Add(UIInitializer.PlayerUI2.PlayerAnimation);
            IsDone = false;
        }

        public override void Execute()
        {
            if (!IsDone)
            {
                this.NextState = this;
                StateMachine.currentLevel.player1.Move();
                UIInitializer.PlayerUI1.PlayerAnimation.Position = StateMachine.currentLevel.player1.Position;
                UIInitializer.PlayerUI1.PlayerAnimation.ChangeAnimation(StateMachine.currentLevel.player1.State);

                StateMachine.currentLevel.player2.Move();
                UIInitializer.PlayerUI2.PlayerAnimation.Position = StateMachine.currentLevel.player2.Position;
                UIInitializer.PlayerUI2.PlayerAnimation.ChangeAnimation(StateMachine.currentLevel.player2.State);
                UIInitializer.PlayerUI2.PlayerAnimation.Tint = Color.Blue;

                System.Console.WriteLine("{0},{1}", StateMachine.currentLevel.player1.Position.X, StateMachine.currentLevel.player1.Position.Y);
                foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
                {
                    if (Key.Button == Keys.P && Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        IsDone = true;
                        this.NextState = new InitialState(this);

                    }
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);

            foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
            {
                if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                {
                    Globals.Graphics.GraphicsDevice.Clear(Color.Red);
                }
                else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Held)
                {
                    Globals.Graphics.GraphicsDevice.Clear(Color.Yellow);
                }
                else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Released)
                {
                    Globals.Graphics.GraphicsDevice.Clear(Color.Green);
                }
            }
        }
    }
}
