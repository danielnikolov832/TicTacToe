using System;
using TicTacToe.GameplayManagement;
using TicTacToe.GameDataManagement;

namespace TicTacToe
{
    // The Startup object
    static class StartupObject
    {
        private static void Main(string[] args)
        {
            DisplayIntroductoryText();
            GameplayManager.OnWin += DisplayWinText;

            GameLog currentGameLog = GameplayManager.PlayGame();

            Console.WriteLine(currentGameLog);

            Console.WriteLine(globals_GameplayTexts.pressAnyKeyToExitText);

            Console.ReadKey();
        }

        private static void DisplayIntroductoryText()
        {
            Console.WriteLine(globals_GameplayTexts.introductoryText +
            "\n");
        }

        private static void DisplayWinText()
        {
            Console.WriteLine("\n" +
            globals_GameplayTexts.winText +
            "\n\n");
        }
    }
}