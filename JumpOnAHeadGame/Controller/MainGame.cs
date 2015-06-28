namespace JumpOnAHeadGame.Controller
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Game1 : Game
    {
        private MonoGameRenderer renderer;
        public Game1()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
            Globals.Content = Content;
            Globals.Content.RootDirectory = "Content";

            Globals.Graphics.PreferredBackBufferWidth = 1280;
            Globals.Graphics.PreferredBackBufferHeight = 1024;

            // SoundTest
            SoundEffect test = Content.Load<SoundEffect>("GoT");
            SoundManager.Add("GoT", test);
            SoundManager.Play("GoT");
            SoundManager.Pause("GoT");
            SoundManager.Resume("GoT");
            SoundManager.Stop("GoT");
        }

        protected override void Initialize()
        {
            renderer = new MonoGameRenderer();
            InputHandler.Initialize();
            StateMachine.Initialize();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.gameTime = gameTime;
            InputHandler.Update();
            StateMachine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Globals.Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            StateMachine.CurrentState.Draw(this.renderer);
        }
    }
}
