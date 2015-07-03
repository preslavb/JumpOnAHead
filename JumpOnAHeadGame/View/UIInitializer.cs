namespace JumpOnAHeadGame.View
{
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class UIInitializer
    {
        public static PlayerUI PlayerUI1 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());
        public static PlayerUI PlayerUI2 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());

        public static SplashScreenUI SplashScreen = new SplashScreenUI(AnimationFactory.CreateSplashScreen());

        public static Background Background = CreateBackground("MenuImage");
        public static Background LevelBackground = CreateBackground("GameBackground");


        public static Button StartButton = CreateButton("StartNormal","StartHover",new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 275));
        public static Button ExitButton = CreateButton("ExitNormal", "ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 375));

        public static Button CreateButton(string buttonNormal,string buttonHover, Vector2 position)
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>(buttonNormal);
            Texture2D startHover = Globals.Content.Load<Texture2D>(buttonHover);

            Sprite startSprite = new Sprite(startNormal, position);
            Button startButton = new Button(startSprite, startHover,startNormal);

            return startButton;
        }

        public static Background CreateBackground(string fileName)
        {
            Texture2D backgroundImage = Globals.Content.Load<Texture2D>(fileName);
            Sprite backgroundSprite = new Sprite(backgroundImage);
            Background background = new Background(backgroundSprite);

            return background;
        }

    }
}
