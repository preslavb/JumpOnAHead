namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    public class MenuState : State
    {
        private int menuId;

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

            this.MenuId = 1;
        }

        private int MenuId
        {
            get
            {
                return this.menuId;
            }
            set
            {
                if (value < 5 && value > 0)
                {
                    this.menuId = value;
                }
            }
        }
        private bool IsDone { get; set; }

        public override void Execute()
        {
            if (!this.IsDone)
            {

                this.NextState = this;

                SoundManager.Play("MenuSound");

                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if (key.Button == Keys.Down && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        MenuId++;
                    }
                    if (key.Button == Keys.Up && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        MenuId--;
                    }

                }

                if (MenuId == 1)
                {
                    UIInitializer.StartButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.StartButton.ChangeToNormalImage();
                }

                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if (MenuId == 1 && Keyboard.GetState().IsKeyDown(Keys.Enter) && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.IsDone = true;
                        SoundManager.Stop("MenuSound");
                        SoundManager.Play("Sound" + Globals.rng.Next(1, 7).ToString());
                        this.NextState = new UpdateState(this);

                        StateMachine.CurrentLevel.Initialize();
                    }
                }
                if (MenuId == 2)
                {
                    UIInitializer.OptionsButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.OptionsButton.ChangeToNormalImage();
                }
                if (MenuId == 2 && Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                }

                if (MenuId == 3)
                {
                    UIInitializer.CreditsButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.CreditsButton.ChangeToNormalImage();
                }
                if (MenuId == 3 && Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                }

                if (MenuId == 4)
                {
                    UIInitializer.ExitButton.ChangeToHoverImage();
                }
                else
                {
                    UIInitializer.ExitButton.ChangeToNormalImage();
                }
                if (MenuId == 4 && Keyboard.GetState().IsKeyDown(Keys.Enter))
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
