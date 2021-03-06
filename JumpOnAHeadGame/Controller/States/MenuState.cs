﻿namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Interface;
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
                        UIInitializer.StartButton.ChangeToHoverImage();
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.CreditsButton.ChangeToNormalImage();
                        UIInitializer.ExitButton.ChangeToNormalImage();
                        foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                            {
                                this.IsDone = true;
                                SoundManager.Pause("MenuSound");
                                Globals.ChosenSound = "Sound" + Globals.Rng.Next(1, 7).ToString();
                                SoundManager.Play(Globals.ChosenSound);
                                this.NextState = new UpdateState(this);

                                int randomLevel = 0;
                                do
                                {
                                    randomLevel = Globals.Rng.Next(0, 3);
                                }
                                while (Globals.ListOfLevels[randomLevel] == StateMachine.CurrentLevel);

                                StateMachine.CurrentLevel = Globals.ListOfLevels[randomLevel];
                                StateMachine.CurrentLevel.Initialize();
                            }
                        }

                        break;

                    case 2:
                        UIInitializer.StartButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToHoverImage();
                        UIInitializer.CreditsButton.ChangeToNormalImage();
                        UIInitializer.ExitButton.ChangeToNormalImage();
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            Globals.Graphics.ToggleFullScreen();
                        }

                        break;

                    case 3:
                        UIInitializer.StartButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToNormalImage();
                        UIInitializer.CreditsButton.ChangeToHoverImage();
                        UIInitializer.ExitButton.ChangeToNormalImage();
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            SoundManager.Play("ErrorSound", 1.0f);
                            this.IsDone = true;
                            this.NextState = new CreditsState(this);
                        }

                        break;

                    case 4:
                        UIInitializer.StartButton.ChangeToNormalImage();
                        UIInitializer.OptionsButton.ChangeToNormalImage();
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
