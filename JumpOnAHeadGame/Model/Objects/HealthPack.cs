﻿namespace JumpOnAHeadGame.Model.Objects
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller;
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View.UI;
    using Microsoft.Xna.Framework;

    public class HealthPack
    {
        public HealthPack(Vector2 position, Animation animation)
        {
            this.Position = position;
            this.Animation = animation;
            this.IsDrawn = false;
            this.IsActive = false;
            this.TimeToSpawn = Globals.Rng.Next(350, 700);
        }

        public Vector2 Position { get; set; }

        public Animation Animation { get; set; }

        public Rectangle Bounds { get; set; }

        public bool IsActive { get; set; }

        public bool IsDrawn { get; set; }

        public int TimeToSpawn { get; set; }

        public void ActOnPlayer(List<Player> players)
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
