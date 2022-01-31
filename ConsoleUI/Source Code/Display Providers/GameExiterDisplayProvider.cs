using ConsoleUI.InputRules;

namespace ConsoleUI.DisplayProviers
{
    internal static class GameExiterDisplayProvider
    {
        private static GameExiter _gameExiter = GameConfig.get_gameExiter;

        internal static string GetGameExitKeyAsString()
        {
            return ConsoleKeyDisplayProvider.GetConsoleKeyAsString(_gameExiter.getset_gameExitKey);
        }
    }
}