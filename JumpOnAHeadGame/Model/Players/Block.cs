namespace JumpOnAHeadGame.Model.Players
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Block
    {
        public Block(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
            this.IsDrawn = false;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }

        public bool IsDrawn { get; set; }

        public void ActOnPlayer(Player player)
        {
            // if (this.Bounds.Intersects(player.Bounds))
            // {
            // }
        }
    }
}
