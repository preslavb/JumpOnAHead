namespace JumpOnAHeadGame.Controller.States
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.View;
    using JumpOnAHeadGame.View.UI;

    public abstract class State
    {
        public State(State nextState)
        {
            this.NextState = nextState;
            this.SpritesInState = new List<IRenderable>();
            this.IsDone = false;
        }

        protected bool IsDone { get; set; }

        public State NextState { get; set; }

        public List<IRenderable> SpritesInState { get; set; }

        public abstract void Execute();

        public virtual void Draw(AbstractRenderer renderer)
        {
            renderer.DrawState(this.SpritesInState);
        }
    }
}
