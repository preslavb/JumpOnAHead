namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework.Input;

    public class MenuState : State
    {
        private bool IsDone { get; set; }

        public MenuState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            IsDone = false;

            this.SpritesInState.Add(UIInitializer.Background.Sprite);
            this.SpritesInState.Add(UIInitializer.StartButton.Sprite);
            this.SpritesInState.Add(UIInitializer.ExitButton.Sprite);
        }

        public override void Execute()
        {
            if (!IsDone)
            {
                this.NextState = this;

                SoundManager.Play("GoT");

                bool mouseStartHover = UIInitializer.StartButton.Sprite.CollisionRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                if (mouseStartHover)
                {
                    UIInitializer.StartButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.StartButton.ChangeToNormalImage();
                }
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseStartHover)
                {
                    IsDone = true;
                    this.NextState = new UpdateState(this);
                }

                bool mouseExitHover = UIInitializer.ExitButton.Sprite.CollisionRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                if (mouseExitHover)
                {
                    UIInitializer.ExitButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.ExitButton.ChangeToNormalImage();
                }
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseExitHover)
                {
                    IsDone = true;
                    SoundManager.Stop("GoT");
                    // TODO: EXIT
                    // using (var game = new Game1())
                    //     game.Exit();
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }

    }
}
