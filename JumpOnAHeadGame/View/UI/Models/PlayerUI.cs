using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpOnAHeadGame.View.UI.Models
{
    public class PlayerUI
    {
        public Animation PlayerAnimation { get; set; }

        public PlayerUI(Animation animation)
        {
            this.PlayerAnimation = animation;

        }
    }
}
