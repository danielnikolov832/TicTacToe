using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.ConsoleConfig
{
    // Defines the functionality this form of UI will have, while event execution takes place
    internal static class EventsForTurnExecution
    {
        internal static void SubscribeToEventsForEventExecution()
        {
            GameplayManager.BeforeEventExecution += GameplayManager_BeforeEventExecution;
            GameplayManager.AfterEventExecution += GameplayManager_AfterEventExecution;
            GameplayManager.OnWin += GameplayManager_OnWin;
        }

        internal static void UnsubscribeFromEventsForEventExecution()
        {
            GameplayManager.BeforeEventExecution -= GameplayManager_BeforeEventExecution;
            GameplayManager.AfterEventExecution -= GameplayManager_AfterEventExecution;
            GameplayManager.OnWin -= GameplayManager_OnWin;
        }

        private static void GameplayManager_BeforeEventExecution(object? sender, int e)
        {
            Console.Clear();

            Console.WriteLine($"Turn { e }");
        }

        private static void GameplayManager_AfterEventExecution(object? sender, TurnData e)
        {
            Console.WriteLine(e.get_tableAtTheEndOfExecution);
        }

        private static void GameplayManager_OnWin(object? sender, EventArgs e)
        {
            Console.WriteLine(globals_GameplayTexts.winText);
        }
    }
}