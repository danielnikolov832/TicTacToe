using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

using ConsoleUI.EventConfig;

namespace ConsoleUI
{
    // The Startup object
    static class StartupObject
    {
        private static void Main(string[] args)
        {
            AllEventsConfig.SubscribeToAllEvents();

            GameLog currentGameLog = GameplayManager.PlayGame(

                GameConfig.get_inputSelector,
                GameConfig.get_startingState,
                GameConfig.get_gameExiter
            );
        }
    }
}