using System;
using TicTacToe.GameDataManagement;

namespace TicTacToe.GameplayManagement.Rules
{
    // Defines and returns the win conditions of the game (whether or not someone won)
    public static class WinConditionRules
    {
        public static bool IsWin()
        {
            if (IsWinOnRow(0) || IsWinOnRow(1) || IsWinOnRow(2)
            || IsWinOnColumn(0) || IsWinOnColumn(1) || IsWinOnColumn(2)
            || IsWinOnDiagonals()) return true;

            return false;
        }

        private static bool IsWinOnRow(int indexForDimension0)
        {
            TableElementStates[,] table = TableData.get_table;

            try
            {
                TableElementStates element1 = table[indexForDimension0, 0];
                TableElementStates element2 = table[indexForDimension0, 1];
                TableElementStates element3 = table[indexForDimension0, 2];

                return AreAllEqualAndChecked(element1, element2, element3);
            }
            catch(IndexOutOfRangeException ioorex)
            {
                throw new ArgumentOutOfRangeException(
                    "Argument 'rowNumber' caused an IndexOutOfRangeException on array access", ioorex);
            }
        }

        private static bool IsWinOnColumn(int indexForDimension1)
        {
            TableElementStates[,] table = TableData.get_table;

            try
            {
                TableElementStates element1 = table[0, indexForDimension1];
                TableElementStates element2 = table[1, indexForDimension1];
                TableElementStates element3 = table[2, indexForDimension1];

                return AreAllEqualAndChecked(element1, element2, element3);
            }
            catch(IndexOutOfRangeException ioorex)
            {
                throw new ArgumentOutOfRangeException(
                    "Argument 'rowNumber' caused an IndexOutOfRangeException on array access", ioorex);
            }
        } 

        private static bool IsWinOnDiagonals()
        {
            TableElementStates[,] table = TableData.get_table;

            TableElementStates element1 = table[0, 0];
            TableElementStates element2 = table[1, 1];
            TableElementStates element3 = table[2, 2];
            TableElementStates element4 = table[2, 0];
            TableElementStates element5 = table[0, 2];

            return (AreAllEqualAndChecked(element1, element2, element3)
            || AreAllEqualAndChecked(element3, element4, element5));
        }

        private static bool AreAllEqualAndChecked(params TableElementStates[] elements)
        {
            TableElementStates element0 = elements[0];

            if (element0 == TableElementStates.Unchecked) return false;

            for (int i = 1; i < elements.Length; i++)
            {
                TableElementStates element = elements[i];

                if (element == TableElementStates.Unchecked
                || element != element0) return false;
            }

            return true;
        }
    }
}