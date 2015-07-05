namespace JumpOnAHeadGame.View.UI
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(71, 120), Globals.Content.Load<Texture2D>("PlayerSpriteSheet"), 60);
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Walking", new Vector2(71, 120), 9, 0));
            currentAnimation.AnimationStates.Add(new AnimationState("Running", new Vector2(71, 120), 12, 1));
            currentAnimation.AnimationStates.Add(new AnimationState("Idle", new Vector2(71, 120), 4, 2));

            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("Idle");
            return currentAnimation;
        }

        public static Animation CreateSplashScreen()
        {
            Animation currentAnimation = new Animation(new Vector2(1280, 1024), Globals.Content.Load<Texture2D>("SplashScreen"), 500);
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Normal", new Vector2(1280, 1024), 1, 0));

            currentAnimation.Tint = Color.White;
            currentAnimation.ChangeAnimation("Normal");

            return currentAnimation;
        }
    }
}
