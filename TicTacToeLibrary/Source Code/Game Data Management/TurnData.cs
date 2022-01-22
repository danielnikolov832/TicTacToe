using System;
using TicTacToe.GameplayManagement;

namespace TicTacToe.GameDataManagement
{
    // Responsible for storing information about a single player turn
    public readonly struct TurnData
    {
        public int get_turnNumber {get; init;}
        public DateTime get_startingTime {get; init;}
        public DateTime get_finishingTime {get; init;}
        public TableElementStates get_playerElementState {get; init;}
        public Table get_tableAtTheEndOfExecution {get; init;}
        public string get_lastRecordedChange {get; init;}

        public TurnData(
            int turnNumber,
            DateTime startingTime, 
            DateTime finishingTime,
            TableElementStates playerElementState,
            Table tableAtTheEndOfExecution,
            string lastRecordedChange)
        {
            this.get_turnNumber = turnNumber;
            this.get_startingTime = startingTime;
            this.get_finishingTime = finishingTime;
            this.get_playerElementState = playerElementState;
            
            this.get_tableAtTheEndOfExecution = new Table(tableAtTheEndOfExecution);

            this.get_lastRecordedChange = lastRecordedChange;
        }

        public override string ToString()
        {
            string output = 
            $"Turn {get_turnNumber}" + "\n" + 
            "\n" +
            $"    Starting time : {get_startingTime}" + "\n" +
            $"    Finishing time : {get_finishingTime}" + "\n" +
            $"    Player element : {get_playerElementState}" + "\n" +
            $"    Last recorded Change : {get_lastRecordedChange}" +"\n" +
            $"    Table on finish : " + "\n" + 
            "\n" + 
            $"{get_tableAtTheEndOfExecution}";

            return output;
        }
    }
}