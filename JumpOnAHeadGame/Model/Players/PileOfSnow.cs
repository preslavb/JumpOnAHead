namespace JumpOnAHeadGame.Model.Players
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class PileOfSnow
    {
        public PileOfSnow(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
            this.IsDrawn = false;
            this.RefillTime = 0;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }

        public bool IsDrawn { get; set; }

        public int RefillTime { get; set; }

        public void RefillSnowballs(List<Player> players)
        {
            foreach (var player in players)
            {
                if (this.Bounds.Intersects(player.Bounds))
                {
                    if (player.Snowballs < 5)
                    {
                        if (this.RefillTime < 30)
                        {
                            this.RefillTime++;
                        }
                        else
                        {
                            player.Snowballs++;
                            this.RefillTime = 0;
                        }
                    }
                }
            }
        }
    }
}
