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

        public static string SetTableElement(
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

                        return globals_GameplayTexts.noChangeOccuredText;
                    }

                    table[indexForDimension0, indexForDimension1] = newElement;

                    areTableElementsChanged[indexForDimension0, indexForDimension1] = true;

                    return globals_GameplayTexts.GetLastRecordedChangeText(indexForDimension0, indexForDimension1);
                }
                catch (IndexOutOfRangeException ioorex)
                {
                    throw new ArgumentOutOfRangeException("Invalid argument/s gave IndexOutOfRangeException on array access", ioorex);
                }
            }
        }
    }
}