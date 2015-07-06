namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    public class MenuState : State
    {
        public MenuState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            this.SpritesInState.Add(UIInitializer.MenuBackground);
            this.SpritesInState.Add(UIInitializer.StartButton.Sprite);
            this.SpritesInState.Add(UIInitializer.OptionsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.CreditsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.ExitButton.Sprite);
        }

        private bool IsDone { get; set; }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                SoundManager.Play("MenuSound");

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
                    this.IsDone = true;
                    SoundManager.Stop("MenuSound");
                    SoundManager.Play("Sound" + Globals.rng.Next(1, 7).ToString());
                    this.NextState = new UpdateState(this);

                    StateMachine.CurrentLevel.Initialize();
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
                    this.IsDone = true;
                    SoundManager.Stop("MenuSound");
                    // TODO: EXIT
                    Game1.self.Exit();
                    
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
