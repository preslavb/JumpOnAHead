namespace JumpOnAHeadGame.View
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class UIInitializer
    {
        private static SplashScreenUI splashScreen = new SplashScreenUI(AnimationFactory.CreateSplashScreen());

        private static Sprite menuBackground = CreateSprite("MenuBackground");
        private static Sprite gameOverBackground = CreateSprite("GameOverBackground");
        private static Sprite pausedBackground = CreateSprite("PausedBackground");
        private static Sprite creditsSprite = CreateSprite("Credits");

        private static Sprite player1WinsSprite = CreateSprite("Player1WINS");
        private static Sprite player2WinsSprite = CreateSprite("Player2WINS");

        private static Sprite player1Name = CreateSprite("Player1");
        private static Sprite player2Name = CreateSprite("Player2");

        private static Sprite healthBarEmptyPlayer1 = CreateSprite("HealthBarEmpty");
        private static Sprite healthBarEmptyPlayer2 = CreateSprite("HealthBarEmpty");

        private static Sprite healthbarFullPlayer1 = CreateSprite("HealthBarFull");
        private static Sprite healthbarFullPlayer2 = CreateSprite("HealthBarFull");

        private static List<Sprite> listOfHealthbars = new List<Sprite> { HealthbarFullPlayer1, HealthbarFullPlayer2 };

        private static Sprite snowballBarEmptyPlayer1 = CreateSprite("SnowballBarEmpty");
        private static Sprite snowballBarEmptyPlayer2 = CreateSprite("SnowballBarEmpty");

        private static Sprite snowballBarFullPlayer1 = CreateSprite("SnowballBarFull");
        private static Sprite snowballBarFullPlayer2 = CreateSprite("SnowballBarFull");

        private static List<Sprite> listOfSnowballBars = new List<Sprite> { SnowballBarFullPlayer1, SnowballBarFullPlayer2 };

        private static Button startButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 275));
        private static Button resumeButton = CreateButton("ResumeNormal", "ResumeHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 275));
        private static Button optionsButton = CreateButton("OptionsNormal", "OptionsHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 375));
        private static Button creditsButton = CreateButton("CreditsNormal", "CreditsHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 475));
        private static Button exitButton = CreateButton("ExitNormal", "ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 775));
        private static Button exitToMenuButton = CreateButton("ExitToMenuNormal", "ExitToMenuHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 775));

        public static SplashScreenUI SplashScreen
        {
            get { return UIInitializer.splashScreen; }
        }

        public static Sprite MenuBackground
        {
            get { return UIInitializer.menuBackground; }
        }

        public static Sprite GameOverBackground
        {
            get { return UIInitializer.gameOverBackground; }
        }

        public static Sprite PausedBackground
        {
            get { return UIInitializer.pausedBackground; }
        }

        public static Sprite CreditsSprite
        {
            get { return UIInitializer.creditsSprite; }
        }

        public static Sprite Player1WinsSprite
        {
            get { return UIInitializer.player1WinsSprite; }
        }

        public static Sprite Player2WinsSprite
        {
            get { return UIInitializer.player2WinsSprite; }
        }

        public static Sprite Player1Name
        {
            get { return UIInitializer.player1Name; }
        }

        public static Sprite Player2Name
        {
            get { return UIInitializer.player2Name; }
        }

        public static Sprite HealthBarEmptyPlayer1
        {
            get { return UIInitializer.healthBarEmptyPlayer1; }
        }

        public static Sprite HealthBarEmptyPlayer2
        {
            get { return UIInitializer.healthBarEmptyPlayer2; }
        }

        public static Sprite HealthbarFullPlayer1
        {
            get { return UIInitializer.healthbarFullPlayer1; }
        }

        public static Sprite HealthbarFullPlayer2
        {
            get { return UIInitializer.healthbarFullPlayer2; }
        }

        public static List<Sprite> ListOfHealthbars1
        {
            get { return UIInitializer.listOfHealthbars; }
        }

        public static Sprite SnowballBarEmptyPlayer1
        {
            get { return UIInitializer.snowballBarEmptyPlayer1; }
        }

        public static Sprite SnowballBarEmptyPlayer2
        {
            get { return UIInitializer.snowballBarEmptyPlayer2; }
        }

        public static Sprite SnowballBarFullPlayer1
        {
            get { return UIInitializer.snowballBarFullPlayer1; }
        }

        public static Sprite SnowballBarFullPlayer2
        {
            get { return UIInitializer.snowballBarFullPlayer2; }
        }

        public static List<Sprite> ListOfSnowballBars
        {
            get { return UIInitializer.listOfSnowballBars; }
        }

        public static Button StartButton
        {
            get { return UIInitializer.startButton; }
        }

        public static Button ResumeButton
        {
            get { return UIInitializer.resumeButton; }
        }

        public static Button OptionsButton
        {
            get { return UIInitializer.optionsButton; }
        }

        public static Button CreditsButton
        {
            get { return UIInitializer.creditsButton; }
        }

        public static Button ExitButton
        {
            get { return UIInitializer.exitButton; }
        }

        public static Button ExitToMenuButton
        {
            get { return UIInitializer.exitToMenuButton; }
        }

        public static Button CreateButton(string buttonNormal, string buttonHover, Vector2 position)
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>(buttonNormal);
            Texture2D startHover = Globals.Content.Load<Texture2D>(buttonHover);

            Sprite startSprite = new Sprite(startNormal, position);
            Button startButton = new Button(startSprite, startHover, startNormal);

            return startButton;
        }

        public static Sprite CreateSprite(string fileName)
        {
            Texture2D tileTexture = Globals.Content.Load<Texture2D>(fileName);

            Sprite tileSprite = new Sprite(tileTexture);

            return tileSprite;
        }
    }
}
