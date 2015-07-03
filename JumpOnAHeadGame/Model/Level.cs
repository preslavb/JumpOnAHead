namespace JumpOnAHeadGame.Model
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI.Models;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Level
    {
        public Player Player1 = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(0, 800));
        public Player Player2 = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(700, 500));

        public List<Snowball> ListOfSnowballs = new List<Snowball>();
    }
}
