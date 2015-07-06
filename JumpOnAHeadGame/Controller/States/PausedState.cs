namespace JumpOnAHeadGame.Controller.States
{
    using System;
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class PausedState : State
    {
        private int menuId;

        public PausedState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            this.SpritesInState.Add(UIInitializer.PausedBackground);
            this.SpritesInState.Add(UIInitializer.ResumeButton.Sprite);
            this.SpritesInState.Add(UIInitializer.OptionsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.ExitToMenuButton.Sprite);

            this.MenuId = 1;
        }

        private bool IsDone { get; set; }

        private int MenuId
        {
            get
            {
                return this.menuId;
            }

            set
            {
                if (value < 5 && value >= 0)
                {
                    this.menuId = value;
                }
            }
        }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                SoundManager.Pause(Globals.ChosenSound);

                SoundManager.Resume("MenuSound");

                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if (key.Button == Keys.Down && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.MenuId++;
                        SoundManager.Play("MenuMove", 1.0f);
                        if (this.MenuId == 4)
                        {
                            this.MenuId = 1;
                        }
                    }

                    if (key.Button == Keys.Up && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.MenuId--;
                        SoundManager.Play("MenuMove", 1.0f);
                        if (this.MenuId == 0)
                        {
                            this.MenuId = 3;
                        }
                    }
                }

                switch (this.MenuId)
                {
                    case 1:
                        UIInitializer.ExitToMenuButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.ResumeButton.ChangeToHoverImage();

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            SoundManager.Pause("MenuSound");
                            SoundManager.Resume(Globals.ChosenSound);
                            this.IsDone = true;
                            this.NextState = new UpdateState(this);
                        }

                        break;

                    case 2:
                        UIInitializer.ResumeButton.ChangeToNormalImage();
                        UIInitializer.ExitToMenuButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToHoverImage();

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                        }

                        break;

                    case 3:
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.ResumeButton.ChangeToNormalImage();
                        UIInitializer.ExitToMenuButton.ChangeToHoverImage();

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            this.IsDone = true;
                            this.NextState = new MenuState(this);
                        }

                        break;
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
