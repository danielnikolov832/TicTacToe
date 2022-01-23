using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // Responsible for holding the data and logic of a game table
    public sealed class Table
    {
        public TableElementStates this[int indexForDimension0, int indexForDimension1]
        {
            get => table[indexForDimension0, indexForDimension1];
            private set => table[indexForDimension0, indexForDimension1] = value;
        }

        internal Table()
        {
            
        }

        // Creates and returns a new instance, 
        // that references a different object in memory
        internal Table(Table copy)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = copy[i, j];

                    areTableElementsChanged[i, j] = copy.areTableElementsChanged[i, j];
                }
            }
        }

        private readonly object __lockObj = new object();

        private TableElementStates[,] table = new TableElementStates[3, 3];
        public TableElementStates[,] get_Table {get => table;}

        private bool[,] areTableElementsChanged = new bool[3, 3];

        public event EventHandler<OnTrySetElementEventArgs>? OnTrySetElement;
        public class OnTrySetElementEventArgs : EventArgs
        {
            public int get_indexForDimension0 {get; init;}
            public int get_indexForDimension1 {get; init;}
            public TableElementStates? get_newElement {get; init;}

            public OnTrySetElementEventArgs(int indexForDimension0, int indexForDimension1, TableElementStates? newElement)
            {
                get_indexForDimension0 = indexForDimension0;
                get_indexForDimension1 = indexForDimension1;
                get_newElement = newElement;
            }
        }

        internal bool TrySetTableElement(
            int indexForDimension0,
            int indexForDimension1,
            TableElementStates newElement)
        {
            try
            {
                if (areTableElementsChanged[indexForDimension0, indexForDimension1])
                {
                    areTableElementsChanged[indexForDimension0, indexForDimension1] = true;

                    OnTrySetElement?.Invoke(
                        this,
                        new OnTrySetElementEventArgs(indexForDimension0, indexForDimension1, null));

                    return false;
                }

                table[indexForDimension0, indexForDimension1] = newElement;

                areTableElementsChanged[indexForDimension0, indexForDimension1] = true;

                OnTrySetElement?.Invoke(
                    this, 
                    new OnTrySetElementEventArgs(indexForDimension0, indexForDimension1, newElement));

                return true;
            }
            catch (IndexOutOfRangeException)
            {
                OnTrySetElement?.Invoke(
                    this, 
                    new OnTrySetElementEventArgs(indexForDimension0, indexForDimension1, null));

                return false;
            }
        }

        public override string ToString()
        {
            string output =
            $" {TableElementDisplayProvider.GetTableElementAsString(table[0, 0])} | {TableElementDisplayProvider.GetTableElementAsString(table[0, 1])} | {TableElementDisplayProvider.GetTableElementAsString(table[0, 2])}" + "\n" +
            "-----------" + "\n" +
            $" {TableElementDisplayProvider.GetTableElementAsString(table[1, 0])} | {TableElementDisplayProvider.GetTableElementAsString(table[1, 1])} | {TableElementDisplayProvider.GetTableElementAsString(table[1, 2])}" + "\n" +
            "-----------" + "\n" +
            $" {TableElementDisplayProvider.GetTableElementAsString(table[2, 0])} | {TableElementDisplayProvider.GetTableElementAsString(table[2, 1])} | {TableElementDisplayProvider.GetTableElementAsString(table[2, 2])} ";

            return output;
        }
    }
}