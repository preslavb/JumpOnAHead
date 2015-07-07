namespace JumpOnAHeadGame.Controller
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Game1 : Game
    {
        private MonoGameRenderer renderer;

        public Game1()
        {
            Self = this;

            Globals.Graphics = new GraphicsDeviceManager(this);
            Globals.Content = this.Content;
            Globals.Content.RootDirectory = "Content";

            this.IsMouseVisible = false;

            Window.Title = "Snow Fighter";

            Globals.Graphics.PreferredBackBufferWidth = 1280;
            Globals.Graphics.PreferredBackBufferHeight = 1024;

            // For Later
            // Globals.Graphics.IsFullScreen = true;
        }

        public static Game1 Self { get; private set; }

        protected override void Initialize()
        {
            this.renderer = new MonoGameRenderer();
            InputHandler.Initialize();
            StateMachine.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            SoundManager.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.GameTime = gameTime;
            InputHandler.Update();
            StateMachine.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           // Globals.Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            StateMachine.CurrentState.Draw(this.renderer);
        }
    }
}
