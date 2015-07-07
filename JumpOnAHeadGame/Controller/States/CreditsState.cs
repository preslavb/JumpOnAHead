namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class CreditsState : State
    {
        public CreditsState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;

            this.SpritesInState.Add(UIInitializer.MenuBackground);
            this.SpritesInState.Add(UIInitializer.CreditsSprite);
            UIInitializer.CreditsSprite.Position = new Vector2(100, 150);
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
