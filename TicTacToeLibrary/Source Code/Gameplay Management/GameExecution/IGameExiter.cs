using System;

namespace TicTacToe.GameplayManagement.GameExecution
{
    public interface IGameExiter
    {
        bool WillExitGameOnBeginTurnExecution();   
        bool WillExitGameImmediately();   
    }
}