using ConsoleUI.InputRules;
using TicTacToe.GameplayManagement;
using TicTacToe.GameplayManagement.GameExecution;
using TicTacToe.GameplayManagement.Rules.Input;

namespace ConsoleUI
{
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