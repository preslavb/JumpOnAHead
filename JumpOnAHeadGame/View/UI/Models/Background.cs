namespace JumpOnAHeadGame.View.UI.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Background
    {
        public Animation Image { get; set; }

        public Background(Animation image)
        {
            this.Image = image;
        }
    }
}
