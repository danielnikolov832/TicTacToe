using System;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.Rules;

namespace TicTacToe.GameplayManagement
{
    // Responsible for managing turns of players and proper gameplay based on the defined rules
    internal static class GameplayManager
    {
        public static int get_currentTurnNumber {get; private set;} = 1;

        public delegate void OnWinHandler();
        public static event OnWinHandler? OnWin;

        public delegate void OnEventExecutionHandler(TurnData turnData);
        public static event OnEventExecutionHandler? OnEventExecution;

        public static GameLog PlayGame()
        {
            TableData.OnTableElementChanged += (int indexForDimension0, int indexForDimension1, TableElementStates? newElement) =>
            {
                if (newElement != null)
                {
                    InputSelectionRules.ChangePlayerElementState();
                }
            };

            GameLog output = new GameLog();

            output = ExecuteGameTurnLoop();           

            return output;
        }

        private static GameLog ExecuteGameTurnLoop()
        {
            GameLog output = new GameLog();

            Console.WriteLine(
                globals_GameplayTexts.pressAnyKeyToContinueText +
                "\n");
            
            while (Console.ReadKey(true).Key != InputSelectionRules.GameExitKey)
            {
                Console.Clear();

                TurnData turn = TurnExecutionRules.ExecuteTurn(
                    get_currentTurnNumber, InputSelectionRules.get_currentSelectedInputState);

                output.AddTurn(turn);

                OnEventExecution?.Invoke(turn);

                get_currentTurnNumber++;

                if (WinConditionRules.IsWin())
                {
                    OnWin?.Invoke();

                    break;
                }

                Console.WriteLine(
                    "\n\n" +
                    globals_GameplayTexts.pressAnyKeyToContinueText +
                    "\n");
            }
            
            return output;
        }
    }
}