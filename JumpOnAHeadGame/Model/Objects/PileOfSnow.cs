namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class PileOfSnow : GameObject
    {
        private const int MAX_PLAYER_SNOWBALLS = 5;
        private const int SNOWBALL_REFILL_TIME = 30;

        public PileOfSnow(Vector2 position, Sprite sprite)
            : base(position, sprite)
        {
            this.RefillTime = 0;
        }

        public int RefillTime { get; set; }

        public override void ActOnPlayer(List<Player> players)
        {
            foreach (var player in players)
            {
                if (this.Bounds.Intersects(player.Bounds))
                {
                    if (player.Snowballs < MAX_PLAYER_SNOWBALLS)
                    {
                        if (this.RefillTime < SNOWBALL_REFILL_TIME)
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
