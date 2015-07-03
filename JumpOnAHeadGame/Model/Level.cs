namespace JumpOnAHeadGame.Model
{
    using JumpOnAHeadGame.Model.Players;
    using Microsoft.Xna.Framework.Input;

    public class Level
    {
        public Player player1 = new Player(Keys.A, Keys.D, Keys.W, Keys.S);
        public Player player2 = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down);

    }
}
