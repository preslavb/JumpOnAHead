namespace JumpOnAHeadGame.View.UI
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using JumpOnAHeadGame.Controller;
    using Microsoft.Xna.Framework.Graphics;
    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation()
        {
            Animation currentAnimation = new Animation(new Vector2(96, 135), Globals.Content.Load<Texture2D>("actions"));
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Running", new Vector2(96, 135), 9, 0));
            currentAnimation.AnimationStates.Add(new AnimationState("Walking", new Vector2(96, 135), 12, 1));
            currentAnimation.AnimationStates.Add(new AnimationState("Idle", new Vector2(96, 135), 4, 2));

            currentAnimation.Tint = Color.White;
            currentAnimation.ChangeAnimation("Running");
            return currentAnimation;
        }
    }
}
