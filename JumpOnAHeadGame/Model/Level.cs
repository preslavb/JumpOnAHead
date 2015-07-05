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

        public List<Player> ListOfPlayers = new List<Player> { Player1, Player2 };

        public List<Snowball> ListOfSnowballs = new List<Snowball>();

        public List<Block> ListOfBlocks = new List<Block> 
        { 
            //TOP BLOCK LINE
            new Block(new Vector2(0, 50), UIInitializer.CreateSprite("IceCube")), 
            new Block(new Vector2(40, 50), UIInitializer.CreateSprite("IceCube")), 
            new Block(new Vector2(80, 50), UIInitializer.CreateSprite("IceCube")), 
            new Block(new Vector2(120, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(160, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(200, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(240, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(280, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(360, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(440, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(520, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(600, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(680, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(760, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(840, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(920, 50), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1000, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(1040, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(1080, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(1120, 50), UIInitializer.CreateSprite("IceCube")),
            new Block(new Vector2(1160, 50), UIInitializer.CreateSprite("IceCube")),        
            new Block(new Vector2(1200, 50), UIInitializer.CreateSprite("IceCube")),        
            new Block(new Vector2(1240, 50), UIInitializer.CreateSprite("IceCube")),        
            //BOT BLOCK LINE
            new Block(new Vector2(0, 950), UIInitializer.CreateSprite("IceBlock")), 
            new Block(new Vector2(50, 950), UIInitializer.CreateSprite("IceBlock")), 
            new Block(new Vector2(100, 950), UIInitializer.CreateSprite("IceBlock")), 
            new Block(new Vector2(150, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(200, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(250, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(300, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(350, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(400, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(450, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(500, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(550, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(600, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(650, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(700, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(750, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(800, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(850, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(900, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(950, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1000, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1050, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1100, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1150, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1200, 950), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(1250, 950), UIInitializer.CreateSprite("IceBlock")),
            //
            new Block(new Vector2(0, 700), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(80, 700), UIInitializer.CreateSprite("IceBlock")),
            new Block(new Vector2(160, 750), UIInitializer.CreateSprite("IceBlock")),
            //
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