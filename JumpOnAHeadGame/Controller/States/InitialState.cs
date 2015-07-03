namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;

    public class InitialState : State
    {
        private bool IsDone { get; set; }

        public InitialState(State nextState)
            :base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            this.SpritesInState.Add(UIInitializer.SplashScreen.splashScreen);
        }

        public override void Execute()
        {
            if (!IsDone)
            {
                this.NextState = this;

                foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
                {
                    if (Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        IsDone = true;
                        this.NextState = new MenuState(this);
                    }
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
            //Globals.Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
