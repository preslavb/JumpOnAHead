namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Interfaces;
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework.Input;

    public class MenuState : State, IMenu
    {
        private int menuId;

        public MenuState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;

            this.SpritesInState.Add(UIInitializer.MenuBackground);
            this.SpritesInState.Add(UIInitializer.StartButton.Sprite);
            this.SpritesInState.Add(UIInitializer.OptionsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.CreditsButton.Sprite);
            this.SpritesInState.Add(UIInitializer.ExitButton.Sprite);

            this.MenuId = 1;
        }

        public int MenuId
        {
            get
            {
                return this.menuId;
            }

            set
            {
                if (value < 6 && value >= 0)
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

                SoundManager.Play("MenuSound");

                foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                {
                    if (key.Button == Keys.Down && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                    {
                        this.MenuId++;
                        SoundManager.Play("MenuMove", 1.0f);
                        if (this.MenuId == 5)
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
                            this.MenuId = 4;
                        }
                    }
                }

                switch (this.MenuId)
                {
                    case 1:
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.ExitButton.ChangeToNormalImage();
                        UIInitializer.StartButton.ChangeToHoverImage();
                        foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                            {
                                this.IsDone = true;
                                SoundManager.Pause("MenuSound");
                                Globals.ChosenSound = "Sound" + Globals.Rng.Next(1, 7).ToString();
                                SoundManager.Play(Globals.ChosenSound);
                                this.NextState = new UpdateState(this);

                                StateMachine.CurrentLevel = Globals.ListOfLevels[Globals.Rng.Next(0, 3)];
                                StateMachine.CurrentLevel.Initialize();
                            }
                        }

                        break;

                    case 2:
                        UIInitializer.StartButton.ChangeToNormalImage();
                        UIInitializer.CreditsButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToHoverImage();
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            Globals.Graphics.ToggleFullScreen();
                        }

                        break;

                    case 3:
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.ExitButton.ChangeToNormalImage();
                        UIInitializer.CreditsButton.ChangeToHoverImage();
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            SoundManager.Play("ErrorSound", 1.0f);
                        }

                        break;

                    case 4:
                        UIInitializer.StartButton.ChangeToNormalImage();
                        UIInitializer.CreditsButton.ChangeToNormalImage();
                        UIInitializer.ExitButton.ChangeToHoverImage();
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            this.IsDone = true;
                            SoundManager.Stop("MenuSound");
                            Game1.Self.Exit();
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
