namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;
    using System.Collections.Generic;

    public abstract class State
    {
        public State(State nextState)
        {
            this.NextState = nextState;
            this.SpritesInState = new List<IRenderable>();
        }

        public State NextState { get; set; }

        public List<IRenderable> SpritesInState { get; set; }

        public abstract void Execute();
        public virtual void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
