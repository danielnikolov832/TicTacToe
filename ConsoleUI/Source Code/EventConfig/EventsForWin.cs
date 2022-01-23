using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.EventConfig
{
    // Defines the functionality this form of UI will have, when a win takes place
    internal static class EventsForWin
    {
        private const string winText = "We won";

        internal static void SubscribeToEventsForWin()
        {
            GameplayManager.OnWin += GameplayManager_OnWin;
        }

        internal static void UnsubscribeFromEventsForWin()
        {
            GameplayManager.OnWin -= GameplayManager_OnWin;
        }

        private static void GameplayManager_OnWin(object? sender, EventArgs e)
        {
            Console.WriteLine(winText);
        }
    }
}