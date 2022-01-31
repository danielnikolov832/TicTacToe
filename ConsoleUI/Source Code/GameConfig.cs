using ConsoleUI.InputRules;
using TicTacToe.GameplayManagement;
using TicTacToe.GameplayManagement.Rules.Input;

namespace ConsoleUI
{
    // Defines and stores the container for the objects that get passed as
    // parameters when GamePlayManager.PlayGame is called in ConsoleUI.StartupObject
    internal static class GameConfig
    {
        private static IInputSelector inputSelector = new InputSelector();
        internal static IInputSelector get_inputSelector { get => inputSelector; }

        private static TableElementStates startingState = TableElementStates.O;
        internal static TableElementStates get_startingState { get => startingState; }

        private static GameExiter gameExiter = new GameExiter(ConsoleKey.Escape);
        internal static GameExiter get_gameExiter { get => gameExiter; }
    }
}