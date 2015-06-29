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

        public static Background GameMenu = new Background(AnimationFactory.CreateGameMenu());


        // TODO
        //  public static Background MenuBackGround = new Background(new Sprite(Globals.Content.Load<Texture2D>("GameMenu")));
        //  public static Background MenuBackGround = CreateBackground();
        //
        //  public static Background CreateBackground()
        //  {
        //      Texture2D backgroundImage = Globals.Content.Load<Texture2D>("GameMenu");
        //      Sprite backgroundSprite = new Sprite(backgroundImage);
        //
        //      Background background = new Background(backgroundSprite);
        //      return background;
        //  }
    }
}
