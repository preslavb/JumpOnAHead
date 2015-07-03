namespace JumpOnAHeadGame.Controller.Managers
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;

    public static class InputHandler
    {
        // private static List<Keys> pressedKeys;
        // private static List<KeyState> pressedKeysStates;
        private enum MouseKeys
        {
            Left,
            Right,
            Middle,
            None
        }

        private enum MouseKeyState
        {
            Held,
            Clicked,
            Released,
            None
        }

        public static KeyboardState CurrentKeyboardState { get; set; }

        public static KeyboardState PreviousKeyboardState { get; set; }

        public static MouseState CurrentMouseState { get; set; }

        public static MouseState PreviousMouseState { get; set; }

        public static List<KeyboardButtonState> ActiveKeys { get; set; }

        public static Keys KeyToCheck { get; set; }

        private static MouseKeys PressedMouseKey { get; set; }

        private static MouseKeyState PressedMouseKeyState { get; set; }

        public static void Initialize()
        {
            ActiveKeys = new List<KeyboardButtonState>();
        }

        public static void Update()
        {
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();

            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();

            CheckKeyState(PreviousKeyboardState, CurrentKeyboardState);
        }

        private static void CheckKeyState(KeyboardState previousState, KeyboardState currentState)
        {
            for (int i = 0; i < currentState.GetPressedKeys().Length; i++)
            {
                KeyToCheck = currentState.GetPressedKeys()[i];
                if (previousState.IsKeyUp(KeyToCheck) && currentState.IsKeyDown(KeyToCheck))
                {
                    // pressedKeys.Add(KeyToCheck);
                    // pressedKeysStates.Add(KeyState.Clicked);
                    ActiveKeys.Add(new KeyboardButtonState(KeyToCheck));
                }
                else if (previousState.IsKeyDown(KeyToCheck) && currentState.IsKeyDown(KeyToCheck))
                {
                    // pressedKeysStates[pressedKeys.IndexOf(KeyToCheck)] = KeyState.Held;
                    foreach (KeyboardButtonState key in ActiveKeys)
                    {
                        if (key.Button == KeyToCheck)
                        {
                            key.ButtonState = KeyboardButtonState.KeyState.Held;
                        }
                    }
                }
            }

            for (int i = 0; i < previousState.GetPressedKeys().Length; i++)
            {
                KeyToCheck = previousState.GetPressedKeys()[i];
                if (previousState.IsKeyDown(KeyToCheck) && currentState.IsKeyUp(KeyToCheck))
                {
                    // pressedKeysStates[pressedKeys.IndexOf(KeyToCheck)] = KeyState.Released;
                    foreach (KeyboardButtonState key in ActiveKeys)
                    {
                        if (key.Button == KeyToCheck)
                        {
                            key.ButtonState = KeyboardButtonState.KeyState.Released;
                        }
                    }
                }
            }

            for (int i = 0; i < ActiveKeys.Count; i++)
            {
                if (previousState.IsKeyUp(ActiveKeys[i].Button) && currentState.IsKeyUp(ActiveKeys[i].Button))
                {
                    ActiveKeys[i].Button = Keys.None;
                    ActiveKeys[i].ButtonState = KeyboardButtonState.KeyState.None;
                }
            }

            // while (ActiveKeys.Contains(Keys.None))
            // {
            //    pressedKeysStates.RemoveAt(pressedKeys.IndexOf(Keys.None));
            //    pressedKeys.RemoveAt(pressedKeys.IndexOf(Keys.None));
            // }
            while (ActiveKeys.Contains(new KeyboardButtonState(Keys.None)))
            {
                ActiveKeys.Remove(new KeyboardButtonState(Keys.None));
            }

            // for (int i = 0; i < ActiveKeys.Count; i++)
            // {
            //    if (ActiveKeys[i].Button == Keys.None)
            //    {
            //
            //    }
            // }
        }

        private static void CheckButtonState(MouseState previousState, MouseState currentState)
        {
            if (previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Left;
                PressedMouseKeyState = MouseKeyState.Clicked;
            }
            else if (previousState.LeftButton == ButtonState.Pressed && currentState.LeftButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Left;
                PressedMouseKeyState = MouseKeyState.Held;
            }
            else if (previousState.LeftButton == ButtonState.Pressed && currentState.LeftButton == ButtonState.Released)
            {
                PressedMouseKey = MouseKeys.Left;
                PressedMouseKeyState = MouseKeyState.Released;
            }
            else if (previousState.RightButton == ButtonState.Released && currentState.RightButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Right;
                PressedMouseKeyState = MouseKeyState.Clicked;
            }
            else if (previousState.RightButton == ButtonState.Pressed && currentState.RightButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Right;
                PressedMouseKeyState = MouseKeyState.Held;
            }
            else if (previousState.RightButton == ButtonState.Pressed && currentState.RightButton == ButtonState.Released)
            {
                PressedMouseKey = MouseKeys.Right;
                PressedMouseKeyState = MouseKeyState.Released;
            }
            else if (previousState.MiddleButton == ButtonState.Released && currentState.MiddleButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Middle;
                PressedMouseKeyState = MouseKeyState.Clicked;
            }
            else if (previousState.MiddleButton == ButtonState.Pressed && currentState.MiddleButton == ButtonState.Pressed)
            {
                PressedMouseKey = MouseKeys.Middle;
                PressedMouseKeyState = MouseKeyState.Held;
            }
            else if (previousState.MiddleButton == ButtonState.Pressed && currentState.MiddleButton == ButtonState.Released)
            {
                PressedMouseKey = MouseKeys.Middle;
                PressedMouseKeyState = MouseKeyState.Released;
            }
            else
            {
                PressedMouseKey = MouseKeys.None;
                PressedMouseKeyState = MouseKeyState.None;
            }
        }
    }
}
