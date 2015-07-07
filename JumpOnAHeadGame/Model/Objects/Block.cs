namespace JumpOnAHeadGame.Model.Objects
{
    using JumpOnAHeadGame.Model.Interfaces;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class Block : IObject
    {
        public Block(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }
    }
}
