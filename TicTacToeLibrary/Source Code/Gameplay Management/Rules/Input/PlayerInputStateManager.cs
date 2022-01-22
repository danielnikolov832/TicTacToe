using System;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.GameExecution;

namespace TicTacToe.GameplayManagement.Rules.Input
{
    public class PlayerInputStateManager
    {
        public PlayerInputStateManager(TableElementStates startingElementState, Table table)
        {
            if (IsValidStartingElementState(startingElementState) == false)
            {
                throw new ArgumentException("startingElementState is not valid, it must satisfy the following :" + " " +
                "(startingElementState == TableElementState.X || startingElementState == TableElementStates.O)" + " " +
                $"but instead it is : { startingElementState }");
            }

            currentSelectedInputState = startingElementState;

            Set_Table_OnTrySetTableElement(table);
        }

        private const string notValidElementStateText = "currentSelectedInputState is not valid";

        private TableElementStates currentSelectedInputState;
        public TableElementStates get_currentSelectedInputState { get => currentSelectedInputState; }

        private bool IsValidStartingElementState(TableElementStates startingElementState)
        {
            if (startingElementState == TableElementStates.X
            || startingElementState == TableElementStates.O)
            {
                return true;
            }

            return false;
        }

        private void Set_Table_OnTrySetTableElement(Table table)
        {
            table.OnTrySetElement += Table_OnTrySetTableElement;

            GameplayManager.OnEndExecuteGameLoop += (object? sender, GameLog e) =>
            {
                table.OnTrySetElement -= Table_OnTrySetTableElement;
            };
        }

        private void ChangePlayerElementState()
        {
            if (currentSelectedInputState == TableElementStates.X)
            {
                currentSelectedInputState = TableElementStates.O;
            }
            else if (currentSelectedInputState == TableElementStates.O)
            {
                currentSelectedInputState = TableElementStates.X;
            }
            else
            {
                throw new Exception(notValidElementStateText);
            }
        }

        private void Table_OnTrySetTableElement(object? sender, Table.OnTrySetElementEventArgs e)
        {
            if (e.get_newElement != null)
            {
                ChangePlayerElementState();
            }
        }   
    }
}