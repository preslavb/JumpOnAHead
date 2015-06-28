namespace JumpOnAHeadGame.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    public class Sprite : IRenderable
    {
        public Vector2 Position { get; set; }
        public virtual Texture2D Texture { get; set; }
        public Color Tint { get; set; }
        public Rectangle SourceRectangle { get; set; }

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
            this.SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
    }
}
