namespace JumpOnAHeadGame.Controller
{
    using System.Collections.Generic;
    using JumpOnAHeadGame.Controller.States;
    using JumpOnAHeadGame.Model.Levels;

    public static class StateMachine
    {
        public static InitialState InitialState { get; set; }

        public static MenuState MenuState { get; set; }

        public static UpdateState UpdateState { get; set; }

        public static Level CurrentLevel { get; set; }

        public static List<State> ListOfStates { get; set; }

        public static State CurrentState { get; set; }

        public static void Initialize()
        {
            InitialState = new InitialState(MenuState);
            MenuState = new MenuState(UpdateState);
            UpdateState = new UpdateState(InitialState);

            InitialState.NextState = MenuState;

            CurrentState = InitialState;
            CurrentLevel = Globals.ListOfLevels[Globals.Rng.Next(0, 3)];
            CurrentLevel.Initialize();
        }

        public static void Update()
        {
            CurrentState.Execute();
            CurrentState = CurrentState.NextState;
        }
    }
}
