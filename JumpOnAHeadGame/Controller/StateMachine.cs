namespace JumpOnAHeadGame.Controller
{
    using JumpOnAHeadGame.Controller.States;
    using JumpOnAHeadGame.Model;
    using System.Collections.Generic;

    public static class StateMachine
    {
        public static List<State> ListOfStates { get; set; }
        public static State CurrentState { get; set; }

        public static InitialState initialState;
        public static MenuState menuState;
        public static UpdateState updateState;

        public static Level currentLevel;

        public static void Initialize()
        {
            initialState = new InitialState(menuState);
            menuState = new MenuState(updateState);
            updateState = new UpdateState(initialState);

            initialState.NextState = menuState;

            CurrentState = initialState;
            currentLevel = new Level();
        }

        public static void Update()
        {
            CurrentState.Execute();
            CurrentState = CurrentState.NextState;
        }
    }
}
