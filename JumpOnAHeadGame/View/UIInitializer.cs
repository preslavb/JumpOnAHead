namespace JumpOnAHeadGame.View
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class UIInitializer
    {
        public static SplashScreenUI SplashScreen = new SplashScreenUI(AnimationFactory.CreateSplashScreen());

        public static Sprite MenuBackground = CreateSprite("MenuBackground");
        public static Sprite LevelBackground = CreateSprite("LevelBackground");
        public static Sprite GameOverBackground = CreateSprite("GameOverBackground");
        public static Sprite PausedBackground = CreateSprite("PausedBackground");

        public static Sprite Player1Name = CreateSprite("Player1");
        public static Sprite Player2Name = CreateSprite("Player2");

        public static Sprite HealthBarEmptyPlayer1 = CreateSprite("HealthBarEmpty");
        public static Sprite HealthBarEmptyPlayer2 = CreateSprite("HealthBarEmpty");

        public static Sprite HealthbarFullPlayer1 = CreateSprite("HealthBarFull");
        public static Sprite HealthbarFullPlayer2 = CreateSprite("HealthBarFull");

        public static List<Sprite> ListOfHealthbars = new List<Sprite> { HealthbarFullPlayer1, HealthbarFullPlayer2 };

        public static Sprite SnowballBarEmptyPlayer1 = CreateSprite("SnowballBarEmpty");
        public static Sprite SnowballBarEmptyPlayer2 = CreateSprite("SnowballBarEmpty");
       
        public static Sprite SnowballBarFullPlayer1 = CreateSprite("SnowballBarFull");
        public static Sprite SnowballBarFullPlayer2 = CreateSprite("SnowballBarFull");
       
        public static List<Sprite> ListOfSnowballBars = new List<Sprite> { SnowballBarFullPlayer1, SnowballBarFullPlayer2 };

        public static Button StartButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 275));
        public static Button ResumeButton = CreateButton("ResumeNormal", "ResumeHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 275));
        public static Button OptionsButton = CreateButton("OptionsNormal", "OptionsHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 375));
        public static Button CreditsButton = CreateButton("CreditsNormal", "CreditsHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 475));
        public static Button ExitButton = CreateButton("ExitNormal", "ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 775));
        public static Button ExitToMenuButton = CreateButton("ExitToMenuNormal", "ExitToMenuHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 775));

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
