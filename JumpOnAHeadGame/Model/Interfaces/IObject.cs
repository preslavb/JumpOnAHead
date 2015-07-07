using JumpOnAHeadGame.View.UI;
using Microsoft.Xna.Framework;
namespace JumpOnAHeadGame.Model.Interfaces
{
    public interface IObject
    {
        Vector2 Position { get; }

        Rectangle Bounds { get; }

        Sprite Sprite { get; }
    }
}
