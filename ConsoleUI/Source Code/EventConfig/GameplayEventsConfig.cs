using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.ConsoleConfig
{
    // Defines the functionality this form of UI will have, by setting up events
    internal static class AllEventsConfig
    {        
        internal static void SubscribeToAllEvents()
        {
            EventsForGameConfig.SubscribeToEventsForGameConfigure();
            EventsForTurnExecution.SubscribeToEventsForEventExecution();
            EventsForGameLoopExecution.SubscribeToEventsForGameLoopExecution();
        }

        internal static void UnsubscribeFromAllEvents()
        {
            EventsForGameConfig.UnsubscribeFromEventsForTable();
            EventsForGameConfig.UnsubscribeToEventsForGameConfigure();
            EventsForTurnExecution.UnsubscribeFromEventsForEventExecution();
            EventsForGameLoopExecution.UnsubscribeFromEventsForGameLoopExecution();
        }
    }
}