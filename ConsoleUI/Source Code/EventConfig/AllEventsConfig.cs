using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.EventConfig
{
    // Defines the functionality this form of UI will have, by setting up events
    internal static class AllEventsConfig
    {        
        internal static void SubscribeToAllEvents()
        {
            EventsForGameConfig.SubscribeToEventsForGameConfigure();
            EventsForTurnExecution.SubscribeToEventsForEventExecution();
            EventsForGameLoopExecution.SubscribeToEventsForGameLoopExecution();
            EventsForDraw.SubscribeToEventsForDraw();
            EventsForWin.SubscribeToEventsForWin();
        }

        internal static void UnsubscribeFromAllEvents()
        {
            EventsForGameConfig.UnsubscribeFromEventsForTable();
            EventsForGameConfig.UnsubscribeToEventsForGameConfigure();
            EventsForTurnExecution.UnsubscribeFromEventsForEventExecution();
            EventsForGameLoopExecution.UnsubscribeFromEventsForGameLoopExecution();
            EventsForDraw.UnsubscribeFromEventsForDraw();
            EventsForWin.UnsubscribeFromEventsForWin();
        }
    }
}