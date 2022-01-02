using System;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.Rules;

namespace TicTacToe.GameplayManagement
{
    // Responsible for managing turns of players and proper gameplay based on the defined rules
    internal static class GameplayManager
    {
        public static int get_currentTurnNumber {get; private set;} = 0;

        public delegate void OnWinHandler();
        public static event OnWinHandler? OnWin;

        public delegate void OnEventExecutionHandler(TurnData turnData);
        public static event OnEventExecutionHandler? OnEventExecution;

        public static GameLog PlayGame()
        {
            GameLog gameLog = new GameLog();

            Console.WriteLine(
                globals_GameplayTexts.pressAnyKeyToContinueText +
                "\n");

            while (Console.ReadKey(true).Key != InputSelectionRules.GameExitKey)
            {
                Console.Clear();

                TurnData turn = ExecuteTurn();

                gameLog.AddTurn(turn);

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

            return gameLog;
        }

        private static TurnData ExecuteTurn()
        {
            DateTime startingTime = DateTime.Now;

            Console.WriteLine($"Turn {get_currentTurnNumber}");

            (short row, short column, TableElementStates selectedInput) = ExecuteInputSelection();

            string lastRecordedChange = TableData.SetTableElement(row - 1, column - 1, selectedInput);
            Console.WriteLine();

            get_currentTurnNumber++;
            TableDisplayProvider.WriteCurrentTableToConsole();

            DateTime finishingTime = DateTime.Now;

            TurnData output = new TurnData(get_currentTurnNumber, startingTime, finishingTime, TableData.get_table, lastRecordedChange);

            OnEventExecution?.Invoke(output);

            return output;
        }

        private static (short, short, TableElementStates) ExecuteInputSelection()
        {
            Console.WriteLine();
            short row = (short)InputSelectionRules.SelectRow();

            Console.WriteLine();
            short column = (short)InputSelectionRules.SelectColumn();

            Console.WriteLine();
            TableElementStates selectedInput = InputSelectionRules.SelectXOrO();

            return (row, column, selectedInput);
        }
    }
}