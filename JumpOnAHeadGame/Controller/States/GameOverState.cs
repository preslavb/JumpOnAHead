namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class GameOverState : State
    {
        public GameOverState(State nextState, int loserIndex)
            : base(nextState)
        {
            this.NextState = nextState;

            this.SpritesInState.Add(UIInitializer.GameOverBackground);
            if (loserIndex == 0)
            {
                this.SpritesInState.Add(UIInitializer.Player2WinsSprite);
                UIInitializer.Player2WinsSprite.Position = new Vector2(300, 600);
            }
            else
            {
                this.SpritesInState.Add(UIInitializer.Player1WinsSprite);
                UIInitializer.Player1WinsSprite.Position = new Vector2(300, 600);
            }
        }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if ((key.Button == Keys.Enter || key.Button == Keys.Escape) && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.IsDone = true;
                        this.NextState = new MenuState(this);
                    }
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
