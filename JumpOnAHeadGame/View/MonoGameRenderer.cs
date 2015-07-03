namespace JumpOnAHeadGame.View
{
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class MonoGameRenderer : AbstractRenderer
    {
        public override void DrawState(List<IRenderable> spritesToDraw)
        {
            Globals.SpriteBatch.Begin();
            foreach (IRenderable item in spritesToDraw)
            {
                Globals.SpriteBatch.Draw(item.Texture, item.Position, item.SourceRectangle, item.Tint);
            }
            Globals.SpriteBatch.End();
        }
    }
}
