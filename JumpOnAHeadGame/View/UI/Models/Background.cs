namespace JumpOnAHeadGame.View.UI.Models
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Background
    {
        public Background(Sprite image)
        {
            this.Sprite = image;
        }

        public Sprite Sprite { get; set; }
    }
}
