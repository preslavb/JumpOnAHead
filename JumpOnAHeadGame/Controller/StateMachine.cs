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
        public static UpdateState updateState;

        public static Level currentLevel;

        public static void Initialize()
        {
            initialState = new InitialState(updateState);
            updateState = new UpdateState(initialState);

            initialState.NextState = updateState;

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
