namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework.Input;

    public class GameOverState : State
    {
        public GameOverState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;

            this.SpritesInState.Add(UIInitializer.GameOverBackground);
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
