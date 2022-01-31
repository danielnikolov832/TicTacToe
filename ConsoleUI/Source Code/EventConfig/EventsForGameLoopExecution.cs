using ConsoleUI.DisplayProviers;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI.EventConfig
{
    // Defines the functionality this form of UI will have, while game loop execution takes place
    internal static class EventsForGameLoopExecution
    {
        private const string introductoryText = "Hi, ready for some good old TicTacToe";

        internal static void SubscribeToEventsForGameLoopExecution()
        {
            GameplayManager.OnBeginExecuteGameLoop += GameplayManager_OnBeginExecuteGameLoop;
            GameplayManager.BeforeSwitchTurn += GameplayManager_BeforeSwitchTurn;
            GameplayManager.OnEndExecuteGameLoop += GameplayManager_OnEndExecuteGameLoop;
        }

        internal static void UnsubscribeFromEventsForGameLoopExecution()
        {
            GameplayManager.OnBeginExecuteGameLoop -= GameplayManager_OnBeginExecuteGameLoop;
            GameplayManager.BeforeSwitchTurn -= GameplayManager_BeforeSwitchTurn;
            GameplayManager.OnEndExecuteGameLoop -= GameplayManager_OnEndExecuteGameLoop;
        }

        private static void GameplayManager_OnBeginExecuteGameLoop(object? sender, EventArgs e)
        {
            Console.WriteLine(introductoryText);
            Console.WriteLine(GetPressAnyKeyToContinueOrPressKeyToExitText());
        }

        private static void GameplayManager_BeforeSwitchTurn(object? sender, EventArgs e)
        {
            Console.WriteLine(GetPressAnyKeyToContinueOrPressKeyToExitText());
        }

        private static string GetPressAnyKeyToContinueOrPressKeyToExitText()
        {
            return $"{globals_GameplayTexts.pressAnyKeyToContinueText} or press {GameExiterDisplayProvider.GetGameExitKeyAsString()} to exit";
        }

        private static void GameplayManager_OnEndExecuteGameLoop(object? sender, GameLog e)
        {
            AllEventsConfig.UnsubscribeFromAllEvents();

            Console.WriteLine(e);

            Console.WriteLine(globals_GameplayTexts.pressAnyKeyToExitText);

            Console.ReadKey();
        }
    }
}