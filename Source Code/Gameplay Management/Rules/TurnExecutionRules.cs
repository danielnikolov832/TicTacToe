using System;
using TicTacToe.GameDataManagement;

namespace TicTacToe.GameplayManagement.Rules
{
    // Defines the rules of executing a single turn
    public static class TurnExecutionRules
    {
        public static TurnData ExecuteTurn(int currentTurnNumber, TableElementStates playerInputState)
        {
            DateTime startingTime = DateTime.Now;

            Console.WriteLine($"Turn {currentTurnNumber}");

            (int row, int column) = ExecuteInputSelection();

            short indexForDimension0 = (short)(row - 1);
            short indexForDimension1 = (short)(column - 1);

            Console.WriteLine();
            
            bool success = TrySetTableAccordingToInput(indexForDimension0, indexForDimension1);

            Console.WriteLine();

            TableDisplayProvider.WriteCurrentTableToConsole();

            string lastRecordedChange = globals_GameplayTexts.GetLastRecordedChangeText(
                success, indexForDimension0, indexForDimension1, InputSelectionRules.get_currentSelectedInputState);

            DateTime finishingTime = DateTime.Now;

            TurnData output = new TurnData(
                currentTurnNumber,
                startingTime,
                finishingTime,
                playerInputState,
                TableData.get_table,
                lastRecordedChange);

            
            return output;
        }

        private static (int, int) ExecuteInputSelection()
        {
            Console.WriteLine();
            int row = InputSelectionRules.SelectRow();

            Console.WriteLine();
            int column = InputSelectionRules.SelectColumn();

            return (row, column);
        }       

        private static bool TrySetTableAccordingToInput(short indexForDimension0, short indexForDimension1)
        {
            bool output = TableData.TrySetTableElement(
                indexForDimension0,
                indexForDimension1,
                InputSelectionRules.get_currentSelectedInputState);

            return output;
        }
    }
}