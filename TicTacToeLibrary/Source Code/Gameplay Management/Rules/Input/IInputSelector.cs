using System;

namespace TicTacToe.GameplayManagement.Rules.Input
{
    public interface IInputSelector
    {
        short SelectRow();
        short RecoverOnFailedSelectRow();
        
        short SelectColumn();
        short RecoverOnFailedSelectColumn();
    }
}