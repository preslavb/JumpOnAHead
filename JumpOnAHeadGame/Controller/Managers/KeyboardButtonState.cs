namespace JumpOnAHeadGame.Controller.Managers
{
    using Microsoft.Xna.Framework.Input;
    public class KeyboardButtonState
    {
        public enum KeyState
        {
            Held,
            Clicked,
            Released,
            None
        }

        public KeyboardButtonState(Keys button)
        {
            this.Button = button;
            this.ButtonState = KeyState.Clicked;
        }

        public Keys Button { get; set; }
        public KeyState ButtonState { get; set; }
    }
}
