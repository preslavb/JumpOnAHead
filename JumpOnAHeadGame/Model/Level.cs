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
        public static Player Player1;
        public static Player Player2;

        public List<Player> ListOfPlayers;

        public List<Snowball> ListOfSnowballs;

        public List<Block> ListOfBlocks;

        public List<PileOfSnow> ListOfPilesOfSnow;

        public void Initialize()
        {
            Player1 = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(50, 800), true);
            Player2 = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(1150, 800), false);

            ListOfPlayers = new List<Player> { Player1, Player2 };

            ListOfSnowballs = new List<Snowball>();

            ListOfPilesOfSnow = new List<PileOfSnow>
            {
                new PileOfSnow(new Vector2(500, 880), UIInitializer.CreateSprite("PileOfSnow")), 
            };

            ListOfBlocks = new List<Block> 
            { 
                // TOP BLOCK LINE
                new Block(new Vector2(0, 70), UIInitializer.CreateSprite("IceCube")), 
                new Block(new Vector2(40, 70), UIInitializer.CreateSprite("IceCube")), 
                new Block(new Vector2(80, 70), UIInitializer.CreateSprite("IceCube")), 
                new Block(new Vector2(120, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(160, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(200, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(240, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(280, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(320, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(360, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(400, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(440, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(480, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(520, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(560, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(600, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(640, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(680, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(720, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(760, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(800, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(840, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(880, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(920, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(960, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1000, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1040, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1080, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1120, 70), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1160, 70), UIInitializer.CreateSprite("IceCube")),        
                new Block(new Vector2(1200, 70), UIInitializer.CreateSprite("IceCube")),        
                new Block(new Vector2(1240, 70), UIInitializer.CreateSprite("IceCube")),        
                // BOT BLOCK LINE
                new Block(new Vector2(0, 950), UIInitializer.CreateSprite("IceBlock")), 
                new Block(new Vector2(80, 950), UIInitializer.CreateSprite("IceBlock")), 
                new Block(new Vector2(160, 950), UIInitializer.CreateSprite("IceBlock")), 
                new Block(new Vector2(240, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(320, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(400, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(480, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(560, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(640, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(720, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(800, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(880, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(960, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(1040, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(1120, 950), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(1200, 950), UIInitializer.CreateSprite("IceBlock")),
                // some
                new Block(new Vector2(0, 700), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(80, 700), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(160, 750), UIInitializer.CreateSprite("IceBlock")),
                // some
                new Block(new Vector2(1040, 750), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(1120, 700), UIInitializer.CreateSprite("IceBlock")),
                new Block(new Vector2(1200, 700), UIInitializer.CreateSprite("IceBlock")),
                // LEFT CUBE LINE
                new Block(new Vector2(0, 250), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(0, 300), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(0, 350), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(0, 400), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(0, 450), UIInitializer.CreateSprite("IceCube")),   
                new Block(new Vector2(0, 500), UIInitializer.CreateSprite("IceCube")),
                // RIGHT CUBE LINE
                new Block(new Vector2(1240, 250), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1240, 300), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1240, 350), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1240, 400), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1240, 450), UIInitializer.CreateSprite("IceCube")),
                new Block(new Vector2(1240, 500), UIInitializer.CreateSprite("IceCube")),
            };
        }
    }
}