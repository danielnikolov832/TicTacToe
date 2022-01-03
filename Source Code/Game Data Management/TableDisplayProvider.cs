using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // Provides the functionality to display any table, or just the current one (Stored in TableData.get_table)
    public static class TableDisplayProvider
    {
        public static string GetTableElementAsString(TableElementStates[,] table, int indexForDimension0, int indexForDimension1)
        {
            TableElementStates element = table[indexForDimension0, indexForDimension1];

            return GetTableElementAsString(element);
        }

        public static string GetTableElementAsString(TableElementStates element)
        {
            switch (element)
            {
                case TableElementStates.Unchecked: return globals_GameplayTexts.Unchecked;
                case TableElementStates.X: return globals_GameplayTexts.X;
                case TableElementStates.O: return globals_GameplayTexts.O;
                default: return globals_GameplayTexts.Unchecked;
            }
        }

        public static string GetElementOfCurrentTableAsString(int indexForDimension0, int indexForDimension1)
        {
            return GetTableElementAsString(TableData.get_table, indexForDimension0, indexForDimension1);
        }

        public static string GetTableAsString(TableElementStates[,] table)
        {
            if (table.GetLength(0) != 3 || table.GetLength(1) != 3)
            {
                throw new ArgumentException("Argument 'table' should be a 3 by 3 array");
            }

            string output =
            $" {GetTableElementAsString(table, 0, 0)} | {GetTableElementAsString(table, 0, 1)} | {GetTableElementAsString(table, 0, 2)}" +
            "\n" +
            "-----------" +
            "\n" +
            $" {GetTableElementAsString(table, 1, 0)} | {GetTableElementAsString(table, 1, 1)} | {GetTableElementAsString(table, 1, 2)}" +
            "\n" +
            "-----------" +
            "\n" +
            $" {GetTableElementAsString(table, 2, 0)} | {GetTableElementAsString(table, 2, 1)} | {GetTableElementAsString(table, 2, 2)} ";

            return output;
        }

        public static string GetCurrentTableAsString()
        {
            return GetTableAsString(TableData.get_table);
        }

        public static void WriteTableToConsole(TableElementStates [,] table)
        {
            Console.WriteLine(GetTableAsString(table));
        }

        public static void WriteCurrentTableToConsole()
        {
            WriteTableToConsole(TableData.get_table);
        }
    }
}