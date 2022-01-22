using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // A static container of an instance of type TicTacToe.GamedataManagement.Table, used as the table of the game
    public static class TableData
    {
        private static Table table = new Table();
        public static Table get_table { get => table; }
    }
}