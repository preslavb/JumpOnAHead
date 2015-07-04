namespace JumpOnAHeadGame.Model
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Level
    {
        public static Player Player1 = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(0, 800));
        public static Player Player2 = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(700, 800));

        public static Block block1 = new Block(new Vector2(200, 750), UIInitializer.CreateSprite("IceBlock"));
        public static Block block2 = new Block(new Vector2(280, 700), UIInitializer.CreateSprite("IceBlock"));
        public static Block block3 = new Block(new Vector2(360, 700), UIInitializer.CreateSprite("IceBlock"));

        public List<Player> ListOfPlayers = new List<Player> { Player1, Player2 };

        public List<Snowball> ListOfSnowballs = new List<Snowball>();

        public List<Block> ListOfBlocks = new List<Block> { block1, block2, block3 };

    }
}