namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Objects;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public abstract class GameObject
    {
        public GameObject(Vector2 position)
        {
            this.Position = position;
        }

        public GameObject(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }

        public abstract void ActOnPlayer(List<Player> players);
    }
}