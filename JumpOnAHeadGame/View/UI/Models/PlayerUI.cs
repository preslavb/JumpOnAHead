namespace JumpOnAHeadGame.View.UI.Models
{
    public class PlayerUI
    {
        public PlayerUI(Animation animation)
        {
            this.PlayerAnimation = animation;
        }

        public Animation PlayerAnimation { get; set; }
    }
}
