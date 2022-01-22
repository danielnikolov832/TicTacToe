using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // Provides the functionality to display a table element state
    public static class TableElementDisplayProvider
    {
        private const string X = "X";
        private const string O = "O";
        private const string Unchecked = " ";

        public static string GetTableElementAsString(TableElementStates element)
        {
            switch (element)
            {
                case TableElementStates.Unchecked: return Unchecked;
                case TableElementStates.X: return X;
                case TableElementStates.O: return O;
                default: return Unchecked;
            }
        }
    }
}