using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.ConsoleConfig
{
    internal static class EventsForDraw
    {
        private const string drawText = "Its a draw";

        internal static void SubscribeToEventsForDraw()
        {
            GameplayManager.OnDraw += GameplayManager_OnDraw;
        }

        internal static void UnsubscribeFromEventsForDraw()
        {
            GameplayManager.OnDraw -= GameplayManager_OnDraw;
        }

        private static void GameplayManager_OnDraw(object? sender, EventArgs e)
        {
            Console.WriteLine(drawText);
        }
    }
}