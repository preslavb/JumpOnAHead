namespace JumpOnAHeadGame.View
{
    using JumpOnAHeadGame.View.UI;
    using JumpOnAHeadGame.View.UI.Models;
    public static class UIInitializer
    {
        public static PlayerUI PlayerUI1 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());
        public static PlayerUI PlayerUI2 = new PlayerUI(AnimationFactory.CreatePlayerAnimation());

        
    }
}
