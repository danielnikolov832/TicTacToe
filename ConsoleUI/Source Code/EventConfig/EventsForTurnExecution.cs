using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

using static ConsoleUI.ConsoleAddedMethods;

namespace ConsoleUI.EventConfig
{
    // Defines the functionality this form of UI will have, while event execution takes place
    internal static class EventsForTurnExecution
    {
        internal static void SubscribeToEventsForEventExecution()
        {
            GameplayManager.BeforeEventExecution += GameplayManager_BeforeEventExecution;
            GameplayManager.AfterEventExecution += GameplayManager_AfterEventExecution;
        }

        internal static void UnsubscribeFromEventsForEventExecution()
        {
            GameplayManager.BeforeEventExecution -= GameplayManager_BeforeEventExecution;
            GameplayManager.AfterEventExecution -= GameplayManager_AfterEventExecution;
        }

        private static void GameplayManager_BeforeEventExecution(object? sender, int e)
        {
            Console.Clear();

            Console.WriteLine($"Turn { e }");
        }

        private static void GameplayManager_AfterEventExecution(object? sender, TurnData e)
        {
            WriteLineWithOptionalLining(e.get_tableAtTheEndOfExecution, true, true);
        }
    }
}