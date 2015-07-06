namespace JumpOnAHeadGame.Model
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public abstract class Level
    {
        public static Player Player1;
        public static Player Player2;

        public Sprite LevelBackground;

        public List<Player> ListOfPlayers;

        public List<Snowball> ListOfSnowballs;

        public List<Block> ListOfBlocks;

        public List<PileOfSnow> ListOfPilesOfSnow;

        public abstract void Initialize();
    }
}