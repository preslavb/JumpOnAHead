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
        public static PlayerUI PlayerUI1 = new PlayerUI(AnimationFactory.CreatePlayerAnimation(Color.White));
        public static PlayerUI PlayerUI2 = new PlayerUI(AnimationFactory.CreatePlayerAnimation(Color.Aquamarine));

        public static List<PlayerUI> ListOfPlayerUIs = new List<PlayerUI> { PlayerUI1, PlayerUI2 };

        public static SplashScreenUI SplashScreen = new SplashScreenUI(AnimationFactory.CreateSplashScreen());

        public static Sprite MenuBackground = CreateSprite("MenuImage");
        public static Sprite LevelBackground = CreateSprite("LevelBackground");

        public static Button StartButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 275));
        public static Button ExitButton = CreateButton("ExitNormal", "ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 775));
        public static Button TestButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 375));

        //// public static Tile IceTile1 = CreateTile("IceTile", new Vector2(150, 50),0.2f);

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
