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

        public static Background Background = CreateBackground("MenuImage");
        public static Background LevelBackground = CreateBackground("LevelBackground");

        public static Button StartButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 275));
        public static Button ExitButton = CreateButton("ExitNormal", "ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 375));
        public static Button TestButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 200) / 2, 800));

        // public static Tile IceTile1 = CreateTile("IceTile", new Vector2(150, 50),0.2f);
        public static Button CreateButton(string buttonNormal, string buttonHover, Vector2 position)
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>(buttonNormal);
            Texture2D startHover = Globals.Content.Load<Texture2D>(buttonHover);

            Sprite startSprite = new Sprite(startNormal, position);
            Button startButton = new Button(startSprite, startHover, startNormal);

            return startButton;
        }

        public static Background CreateBackground(string fileName)
        {
            Texture2D backgroundTexture = Globals.Content.Load<Texture2D>(fileName);

            Sprite backgroundSprite = new Sprite(backgroundTexture);
            Background background = new Background(backgroundSprite);

            return background;
        }

      //  public static Tile CreateTile(string fileName, Vector2 position, float scale)
      //  {
      //      Texture2D tileTexture = Globals.Content.Load<Texture2D>(fileName);
      //
      //      Sprite tileSprite = new Sprite(tileTexture, position, scale);
      //      Tile tile = new Tile(tileSprite);
      //
      //      return tile;
      //  }

        public static Sprite CreateSnowball(string fileName, Vector2 position, float scale)
        {
            Texture2D tileTexture = Globals.Content.Load<Texture2D>(fileName);
      
            Sprite tileSprite = new Sprite(tileTexture, position, scale);
     
            return tileSprite;
        }
    }
}
