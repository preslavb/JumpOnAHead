namespace JumpOnAHeadGame.Model.Interfaces
{
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public interface IObject
    {
        Vector2 Position { get; }

        Rectangle Bounds { get; }

        Sprite Sprite { get; }
    }
}
