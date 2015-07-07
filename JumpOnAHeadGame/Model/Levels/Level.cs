namespace JumpOnAHeadGame.Model.Levels
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Objects;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public abstract class Level
    {
        public static Player Player1 { get; set; }

        public static Player Player2 { get; set; }

        public Sprite LevelBackground { get; set; }

        public List<Player> ListOfPlayers { get; set; }

        public List<GameObject> ListOfGameObjects { get; set; }

        public List<Snowball> ListOfSnowballs { get; set; }

        public List<HealthPack> ListOfHealthPacks { get; set; }

        public abstract void Initialize();
    }
}