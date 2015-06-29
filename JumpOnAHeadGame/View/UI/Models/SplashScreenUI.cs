using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpOnAHeadGame.View.UI.Models
{
    public class SplashScreenUI
    {
        public Animation splashScreen { get; set; }

        public SplashScreenUI(Animation animation)
        {
            this.splashScreen = animation;
        }
    }
}
