namespace JumpOnAHeadGame.View.UI.Models
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Tile 
    {
        public Tile(Sprite sprite)
        {
            this.Sprite = sprite;
        }

        public Sprite Sprite { get; set; }
    }
}
