namespace JumpOnAHeadGame.View
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MonoGameRenderer : AbstractRenderer
    {
        public override void DrawState(List<IRenderable> spritesToDraw)
        {
            Globals.SpriteBatch.Begin();
            foreach (IRenderable item in spritesToDraw)
            {
                if (item.IsFacingRight)
                {
                    Globals.SpriteBatch.Draw(item.Texture, item.Position, item.SourceRectangle, item.Tint, 0.0f, Vector2.Zero, item.Scale, SpriteEffects.None, 0);
                }
                else
                {
                    Globals.SpriteBatch.Draw(item.Texture, item.Position, item.SourceRectangle, item.Tint, 0.0f, Vector2.Zero, item.Scale, SpriteEffects.FlipHorizontally, 0);
                }
            }

            Globals.SpriteBatch.End();
        }
    }
}
