namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    public class PausedState : State
    {
        public PausedState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            this.SpritesInState.Add(UIInitializer.PausedBackground);

            this.SpritesInState.Add(UIInitializer.ResumeButton.Sprite);
            this.SpritesInState.Add(UIInitializer.OptionsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.ExitToMenuButton.Sprite);
        }

        private bool IsDone { get; set; }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                bool mouseResumeHover = UIInitializer.ResumeButton.Sprite.CollisionRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                if (mouseResumeHover)
                {
                    UIInitializer.ResumeButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.ResumeButton.ChangeToNormalImage();
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseResumeHover)
                {
                    this.IsDone = true;
                    this.NextState = new UpdateState(this);
                }

                bool mouseExitToMenuHover = UIInitializer.ExitToMenuButton.Sprite.CollisionRectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
                if (mouseExitToMenuHover)
                {
                    UIInitializer.ExitToMenuButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.ExitToMenuButton.ChangeToNormalImage();
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseExitToMenuHover)
                {
                    this.IsDone = true;
                    this.NextState = new MenuState(this);
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
