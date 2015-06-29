namespace JumpOnAHeadGame.View
{
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Monopoly.View.UI;

    public static class UIInitializer
    {
        public static PlayerUI PlayerUI1 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());
        public static PlayerUI PlayerUI2 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());

        public static SplashScreenUI SplashScreen = new SplashScreenUI(AnimationFactory.CreateSplashScreen());

        public static Background Background = CreateBackground();

        public static Button StartButton = CreateStartButton();
        public static Button ExitButton = CreateExitButton();

        public static Button CreateStartButton()
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>("StartNormal");
            Texture2D startHover = Globals.Content.Load<Texture2D>("StartHover");

            Sprite startSprite = new Sprite(startNormal, new Vector2((Globals.Graphics.PreferredBackBufferWidth-startNormal.Width)/2, 275));
            Button startButton = new Button(startSprite, startHover,startNormal);

            return startButton;
        }

        public static Button CreateExitButton()
        {
            Texture2D exitNormal = Globals.Content.Load<Texture2D>("ExitNormal");
            Texture2D exitHover = Globals.Content.Load<Texture2D>("ExitHover");

            Sprite exitSprite = new Sprite(exitNormal, new Vector2((Globals.Graphics.PreferredBackBufferWidth - exitNormal.Width) / 2, 375));
            Button startButton = new Button(exitSprite, exitHover, exitNormal);

            return startButton;
        }

        public static Background CreateBackground()
        {
            Texture2D backgroundImage = Globals.Content.Load<Texture2D>("MenuImage");
            Sprite backgroundSprite = new Sprite(backgroundImage);
            Background background = new Background(backgroundSprite);

            return background;
        }

    }
}
