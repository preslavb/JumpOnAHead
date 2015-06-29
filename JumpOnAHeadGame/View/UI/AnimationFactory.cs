﻿namespace JumpOnAHeadGame.View.UI
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using JumpOnAHeadGame.Controller;
    using Microsoft.Xna.Framework.Graphics;
    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation()
        {
            Animation currentAnimation = new Animation(new Vector2(96, 135), Globals.Content.Load<Texture2D>("PlayerSpriteSheet"));
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Running", new Vector2(96, 135), 9, 0));
            currentAnimation.AnimationStates.Add(new AnimationState("Walking", new Vector2(96, 135), 12, 1));
            currentAnimation.AnimationStates.Add(new AnimationState("Idle", new Vector2(96, 135), 4, 2));

            currentAnimation.Tint = Color.White;
            currentAnimation.ChangeAnimation("Running");
            return currentAnimation;
        }

        public static Animation CreateSplashScreen()
        {
            Animation currentAnimation = new Animation(new Vector2(1280, 1024), Globals.Content.Load<Texture2D>("SplashScreen"));
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Normal", new Vector2(1280, 1024), 1, 0));


            currentAnimation.Tint = Color.White;
            currentAnimation.ChangeAnimation("Normal");

            return currentAnimation;
        }

        public static Animation CreateGameMenu()
        {
            Animation currentAnimation = new Animation(new Vector2(1280, 1024), Globals.Content.Load<Texture2D>("GameMenu"));
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState("Initial", new Vector2(1280, 1024), 0, 0));

            currentAnimation.Tint = Color.White;
            currentAnimation.ChangeAnimation("Initial");

            return currentAnimation;
        }
    }
}
