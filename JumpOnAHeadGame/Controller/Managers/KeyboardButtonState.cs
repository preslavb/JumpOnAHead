namespace JumpOnAHeadGame.Controller.Managers
{
    using Microsoft.Xna.Framework.Input;

    public class KeyboardButtonState
    {
        public KeyboardButtonState(Keys button)
        {
            this.Button = button;
            this.ButtonState = KeyState.Clicked;
        }

        public enum KeyState
        {
            Held,
            Clicked,
            Released,
            None
        }

        public Keys Button { get; set; }

        public KeyState ButtonState { get; set; }
    }
}
