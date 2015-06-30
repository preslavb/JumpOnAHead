namespace JumpOnAHeadGame.Model
{
    using JumpOnAHeadGame.Model.Players;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Level
    {
        public Player player1 = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(0,800));
        public Player player2 = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(1200,800));

    }
}
