namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class HealthPack : GameObject
    {
        public HealthPack(Vector2 position, Animation animation)
            : base(position)
        {
            this.Animation = animation;
            this.IsDrawn = false;
            this.IsActive = true;
        }

        public Animation Animation { get; set; }

        public bool IsActive { get; set; }

        public bool IsDrawn { get; set; }

        public override void ActOnPlayer(List<Player> players)
        {
            foreach (var player in players)
            {
                if (this.Bounds.Intersects(player.Bounds))
                {
                    SoundManager.Play("HealthPack");
                    player.Health += 50;
                    if (player.Health > 100)
                    {
                        player.Health = 100;
                    }

                    this.IsActive = false;
                }
            }
        }
    }
}
