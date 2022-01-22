using System;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.Rules.Input;

namespace TicTacToe.GameplayManagement.Rules
{
    // Defines the rules of executing a single turn
    internal static class TurnExecutionRules
    {
        private const string noChangeOccuredText = "No change occured";

        internal static TurnData ExecuteTurn(
            int currentTurnNumber,
            IInputSelector inputSelector, 
            TableElementStates playerInputState, 
            Table table)
        {
            DateTime startingTime = DateTime.Now;

            (short indexForDimension0, short indexForDimension1) = 
            TableCoordinateSelectionRules.GetCoordinatesFromRowAndColumn(inputSelector);
            
            bool success = table.TrySetTableElement(indexForDimension0, indexForDimension1, playerInputState);

            string lastRecordedChange = GetLastRecordedChangeText(
                success, indexForDimension0, indexForDimension1, playerInputState);

            DateTime finishingTime = DateTime.Now;

            TurnData output = new TurnData(
                currentTurnNumber,
                startingTime,
                finishingTime,
                playerInputState,
                table,
                lastRecordedChange);

            return output;
        }

        private static string GetLastRecordedChangeText(
            bool isChanged, int indexForDimension0, int indexForDimension1, TableElementStates newElement)
        {
            if (isChanged == false)
            {
                return noChangeOccuredText;
            }

            return $"Changed element at [{indexForDimension0 + 1}, {indexForDimension1 + 1}] to " + 
            $"{TableElementDisplayProvider.GetTableElementAsString(newElement)}";
        }
    }
}