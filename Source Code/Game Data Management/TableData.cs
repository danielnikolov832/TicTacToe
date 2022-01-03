using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // Container of the table (the collection of X's and O's in a table) of the game
    public static class TableData
    {
        private static readonly object __lockObj = new object();

        private static TableElementStates[,] table = new TableElementStates[3, 3];
        public static TableElementStates[,] get_table { get => table; }

        private static bool[,] areTableElementsChanged = new bool[3, 3];

        public delegate void OnTableElementChangedHandler(
            int indexForDimension0,
            int indexForDimension1, 
            TableElementStates? newElement);
        public static event OnTableElementChangedHandler? OnTableElementChanged;

        public static void SetTableElement(
            int indexForDimension0,
            int indexForDimension1,
            TableElementStates newElement)
        {
            lock (__lockObj)
            {
                try
                {
                    if (areTableElementsChanged[indexForDimension0, indexForDimension1])
                    {
                        Console.WriteLine(globals_GameplayTexts.alreadyAssignedText);

                        OnTableElementChanged?.Invoke(indexForDimension0, indexForDimension1, null);

                        return;
                    }

                    table[indexForDimension0, indexForDimension1] = newElement;

                    areTableElementsChanged[indexForDimension0, indexForDimension1] = true;

                    OnTableElementChanged?.Invoke(indexForDimension0, indexForDimension1, newElement);
                }
                catch (IndexOutOfRangeException ioorex)
                {
                    throw new ArgumentOutOfRangeException("Invalid argument/s gave IndexOutOfRangeException on array access", ioorex);
                }
            }
        }
    }
}