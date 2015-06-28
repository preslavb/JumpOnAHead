namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class InitialState : State
    {
        public InitialState(State nextState)
            :base(nextState)
        {
            this.NextState = nextState;
            Animation playerAnimation = AnimationFactory.CreatePlayerAnimation();
            this.SpritesInState.Add(playerAnimation);
        }

        public override void Execute()
        {
        }

        public override void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
            Globals.Graphics.GraphicsDevice.Clear(Color.White);
        }
    }
}
