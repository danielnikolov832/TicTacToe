using System;

using TicTacToe.GameplayManagement;
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
                new InputSelector(),
                TableElementStates.O,
                new GameExiter(ConsoleKey.Escape));
        }
    }
}