namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class PileOfSnow
    {
        public PileOfSnow(Vector2 position, Sprite sprite)
        {
            this.Position = position;
            this.Sprite = sprite;
            this.RefillTime = 0;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public Sprite Sprite { get; set; }

        public int RefillTime { get; set; }

        public void ActOnPlayer(List<Player> players)
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
