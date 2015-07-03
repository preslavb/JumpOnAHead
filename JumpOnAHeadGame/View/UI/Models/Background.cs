namespace JumpOnAHeadGame.View.UI.Models
{
    using JumpOnAHeadGame.View.UI;

    public class Background
    {
        public Background(Sprite image)
        {
            this.Sprite = image;
        }

        public Sprite Sprite { get; set; }
    }
}
