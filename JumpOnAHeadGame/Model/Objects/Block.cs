namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class Block : GameObject
    {
        public Block(Vector2 position, Sprite sprite)
            :base(position, sprite)
        {
        }

        public override void ActOnPlayer(List<Player> players)
        {
            throw new System.NotImplementedException();
        }
    }
}
