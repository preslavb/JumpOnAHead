namespace JumpOnAHeadGame.View.UI
{
    using JumpOnAHeadGame.Controller;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    public class Animation : IRenderable
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Color Tint { get; set; }
        public Texture2D Texture
        {
            get
            {
                this.Update();
                return texture;
            }
            set
            {
                this.texture = value;
            }
        }
        public Rectangle SourceRectangle { get; set; }
        public List<AnimationState> AnimationStates { get; set; }
        private AnimationState CurrentAnimationState { get; set; }
        private int SwitchFrameTimer { get; set; }
        private int ElapsedMilliseconds { get; set; }

        public Animation(Vector2 frameDimensions, Texture2D spriteSheet, int switchFrameTimer)
        {
            this.SourceRectangle = new Rectangle(0, 0, (int)frameDimensions.X, (int)frameDimensions.Y);
            this.Texture = spriteSheet;

            this.SwitchFrameTimer = switchFrameTimer;
        }

        private void Update()
        {
            this.ElapsedMilliseconds += Globals.gameTime.ElapsedGameTime.Milliseconds;
            if (this.ElapsedMilliseconds >= this.SwitchFrameTimer)
            {
                this.ElapsedMilliseconds = 0;

                this.SourceRectangle = new Rectangle(this.SourceRectangle.X + this.SourceRectangle.Width - 1, this.SourceRectangle.Y, this.SourceRectangle.Width, this.SourceRectangle.Height);
                if (SourceRectangle.X >= CurrentAnimationState.RowOfFrames.Width)
                {
                    this.SourceRectangle = new Rectangle(0, this.SourceRectangle.Y, this.SourceRectangle.Width, this.SourceRectangle.Height);
                }
            }
        }
        public void ChangeAnimation(string nameOfAction)
        {
            foreach (AnimationState state in this.AnimationStates)
            {
                if (state.Name == nameOfAction && state!=this.CurrentAnimationState)
                {
                    this.CurrentAnimationState = state;
                    this.SourceRectangle = new Rectangle(0, state.RowOfFrames.Top, SourceRectangle.Width, SourceRectangle.Height);
                    break;
                }
            }
        }
    }
}
