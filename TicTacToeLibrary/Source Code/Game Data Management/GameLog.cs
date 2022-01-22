using System;
using System.Collections.Generic;

namespace TicTacToe.GameDataManagement
{
    // Stores the data from the turns of 1 game
    public class GameLog
    {
        private List<TurnData> turns = new List<TurnData>();
        public List<TurnData> get_turns { get => turns;}

        public TurnData this[int index]
        {
            get => turns[index];
        }

        internal void AddTurn(TurnData turn) => turns.Add(turn);

        public override string ToString()
        {
            string output = string.Empty;

            output += 
            "Game log :" + "\n" + 
            "\n";

            foreach (TurnData turn in turns)
            {
                output += turn.ToString() + "\n" +
                "\n";
            }

            return output;
        }
    }
}