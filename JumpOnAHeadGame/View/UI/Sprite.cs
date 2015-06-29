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
        public Rectangle CollisionRectangle { get; set; }

        public Sprite(Texture2D texture)
            : this(texture, new Vector2())
        {
        }
        public Sprite(Texture2D texture , Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.SourceRectangle = new Rectangle(0,0, texture.Width, texture.Height);
            this.Tint = Color.White;
        }
    }
}
