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
            TableCoordinateSelectionRules.GetCoordinatesFromRowAndColumnInInputSelector(inputSelector);
            
            bool success = table.TrySetTableElement(indexForDimension0, indexForDimension1, playerInputState);

            if (success == false)
            {
                return ExecuteTurn(currentTurnNumber, inputSelector, playerInputState, table);
            }

            string lastRecordedChange = $"Changed element at [{indexForDimension0 + 1}, {indexForDimension1 + 1}] to " + 
            $"{TableElementDisplayProvider.GetTableElementAsString(playerInputState)}";

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
    }
}