using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpOnAHeadGame.View.UI.Models
{
    public class GameMenuUI
    {
        public Animation gameMenu { get; set; }

        public GameMenuUI(Animation animation)
        {
            this.gameMenu = animation;
        }
    }
}
