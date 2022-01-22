using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.ConsoleConfig
{
    // Defines the functionality this form of UI will have, when game config takes place
    internal static class EventsForGameConfig
    {
        private static readonly object __lockObj = new object();

        private static Table? table;
        public static Table? Table
        { 
            get => table;
            private set
            {
                lock (__lockObj)
                {
                    table = value;
                }
            }
        }

        internal static void SubscribeToEventsForGameConfigure()
        {
            GameplayManager.OnEndGameConfigure += GameplayManager_OnEndGameConfigure;
        }

        internal static void UnsubscribeToEventsForGameConfigure()
        {
            GameplayManager.OnEndGameConfigure -= GameplayManager_OnEndGameConfigure;
        }

        private static void GameplayManager_OnEndGameConfigure(object? sender, GameplayManager.OnEndGameConfigureEventArgs e)
        {
            ConfigureTableEvents(e);
        }

        private static void ConfigureTableEvents(GameplayManager.OnEndGameConfigureEventArgs e)
        {
            Table = e.get_table;

            Table.OnTrySetElement += Table_OnTrySetElement;
        }

        internal static void UnsubscribeFromEventsForTable()
        {
            if (table != null)
            {
                table.OnTrySetElement -= Table_OnTrySetElement;
            }
        }

        private static void Table_OnTrySetElement(object? sender, Table.OnTrySetElementEventArgs e)
        {
            if (e.get_newElement == null)
            {
                Console.WriteLine(globals_GameplayTexts.unsuccessfulAssignmentText);
            }
        }
    }
}