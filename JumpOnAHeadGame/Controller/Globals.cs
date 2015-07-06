namespace JumpOnAHeadGame.Controller
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using JumpOnAHeadGame.Model;

    public static class Globals
    {
        private static Random rng = new Random();

        public static Random Rng
        {
            get { return rng; }
            set { rng = value; }
        }
        
        public static GraphicsDeviceManager Graphics { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static ContentManager Content { get; set; }

        public static GameTime GameTime { get; set; }

        public static string ChosenSound { get; set; }

        public static List<Level> ListOfLevels = new List<Level>{ new LevelOne(), new LevelTwo(), new LevelThree()};
    }
}
