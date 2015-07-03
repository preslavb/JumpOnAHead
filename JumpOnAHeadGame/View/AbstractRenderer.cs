namespace JumpOnAHeadGame.View
{
    using System;
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class AbstractRenderer
    {
        public virtual void Initialize()
        {
            throw new ArgumentException("You need to use a specific renderer, and you're trying to use the abstract one");
        }

        public virtual void DrawState(List<IRenderable> spritesToDraw)
        {
            throw new ArgumentException("You need to use a specific renderer, and you're trying to use the abstract one");
        }
    }
}
