namespace Monopoly.View.UI
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Background
    {
        public Background(Sprite image)
        {
            this.Image = image;
        }

        public Sprite Image { get; set; }
    }
}
