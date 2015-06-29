namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class MenuState : State
    {
        private bool IsDone { get; set; }

        public MenuState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            IsDone = false;

            this.SpritesInState.Add(UIInitializer.GameMenu.Image);            
            // TODO
            // this.SpritesInState.Add(UIInitializer.MenuBackGround.Image);
        }

        public override void Execute()
        {
            if (!IsDone)
            {
                this.NextState = this;

                SoundManager.Play("GoT");

                foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
                {
                    if (Key.Button != Keys.Escape && Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        IsDone = true;
                        this.NextState = new UpdateState(this);
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
