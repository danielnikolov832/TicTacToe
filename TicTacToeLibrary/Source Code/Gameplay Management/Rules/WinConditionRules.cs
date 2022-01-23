using System;
using TicTacToe.GameDataManagement;

namespace TicTacToe.GameplayManagement.Rules
{
    // Defines and returns the win conditions of the game (whether or not someone won)
    internal static class WinConditionRules
    {
        internal static bool IsTableDraw(Table table)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    TableElementStates element = table[i, j];

                    if (element == TableElementStates.Unchecked) return false;
                }
            }

            return true;
        }

        internal static bool IsTableWin(Table table)
        {
            if (IsTableWinOnRow(table, 0) || IsTableWinOnRow(table, 1) || IsTableWinOnRow(table, 2)
            || IsTableWinOnColumn(table, 0) || IsTableWinOnColumn(table, 1) || IsTableWinOnColumn(table, 2)
            || IsTableWinOnDiagonals(table)) return true;

            return false;
        }

        private static bool IsTableWinOnRow(Table table, int indexForDimension0)
        {
            TableElementStates element1 = table[indexForDimension0, 0];
            TableElementStates element2 = table[indexForDimension0, 1];
            TableElementStates element3 = table[indexForDimension0, 2];

            return AreAllEqualAndChecked(element1, element2, element3);            
        }

        private static bool IsTableWinOnColumn(Table table, int indexForDimension1)
        {
            TableElementStates element1 = table[0, indexForDimension1];
            TableElementStates element2 = table[1, indexForDimension1];
            TableElementStates element3 = table[2, indexForDimension1];

            return AreAllEqualAndChecked(element1, element2, element3);
        } 

        private static bool IsTableWinOnDiagonals(Table table)
        {
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