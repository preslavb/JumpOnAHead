﻿namespace JumpOnAHeadGame.Model.Objects
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class Block
    {
        public Block(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }
    }
}