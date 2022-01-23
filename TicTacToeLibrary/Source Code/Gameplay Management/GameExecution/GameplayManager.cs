using System;
using TicTacToe.GameDataManagement;
using TicTacToe.GameplayManagement.Rules;
using TicTacToe.GameplayManagement.Rules.Input;

namespace TicTacToe.GameplayManagement.GameExecution
{
    // Responsible for managing turns of players and proper gameplay based on the defined rules
    public static class GameplayManager
    {
        public static int get_currentTurnNumber {get; private set;} = 1;

        public static event EventHandler<OnEndGameConfigureEventArgs>? OnEndGameConfigure;
        public class OnEndGameConfigureEventArgs : EventArgs
        {
            public Table get_table {get; init;}
            public PlayerInputStateManager get_playerInputStateManager {get; init;}

            public OnEndGameConfigureEventArgs(Table table, PlayerInputStateManager playerInputStateManager)
            {
                get_table = table;
                get_playerInputStateManager = playerInputStateManager;
            }
        }

        public static event EventHandler<int>? BeforeEventExecution;
    
        public static event EventHandler? OnWin;

        public static event EventHandler? OnDraw;
    
        public static event EventHandler<TurnData>? AfterEventExecution;

        public static event EventHandler? BeforeSwitchTurn;

        public static event EventHandler? OnBeginExecuteGameLoop;

        public static event EventHandler<GameLog>? OnEndExecuteGameLoop;

        public static GameLog PlayGame(
            IInputSelector inputSelector,
            TableElementStates startingElementState,
            IGameExiter gameExiter)
        {
            Table table = TableData.get_table;
            PlayerInputStateManager playerInputStateManager =
            new PlayerInputStateManager(startingElementState, table);

            OnEndGameConfigure?.Invoke(null, new OnEndGameConfigureEventArgs(table, playerInputStateManager));

            GameLog output = ExecuteGameLoop(table, inputSelector, playerInputStateManager, gameExiter);

            return output;
        }

        // Maybe Remove, and add a way for custom interpretation by consumers

        // MAKE SUPPORT FOR THE OTHER TYPE OF GAME EXIT AND FOR PAUSE
        private static GameLog ExecuteGameLoop(
            Table table,
            IInputSelector inputSelector, 
            PlayerInputStateManager playerInputStateManager, 
            IGameExiter gameExiter)
        {
            GameLog output = new GameLog();

            OnBeginExecuteGameLoop?.Invoke(null, EventArgs.Empty);
            
            while (gameExiter.WillExitGameOnBeginTurnExecution() == false)
            {
                TurnData turn = ExecuteTurnInGameLoop(table, inputSelector, playerInputStateManager);

                output.AddTurn(turn);

                Table tableAtTheEndOfExecution = turn.get_tableAtTheEndOfExecution;

                bool isTableWin = WinConditionRules.IsTableWin(tableAtTheEndOfExecution);

                if (isTableWin)
                {
                    OnWin?.Invoke(null, EventArgs.Empty);

                    break;
                }

                bool IsTableDraw = WinConditionRules.IsTableDraw(tableAtTheEndOfExecution);
                
                if (IsTableDraw)
                {
                    OnDraw?.Invoke(null, EventArgs.Empty);

                    break;
                }

                BeforeSwitchTurn?.Invoke(null, EventArgs.Empty);
            }

            OnEndExecuteGameLoop?.Invoke(null, output);

            return output;
        }

        private static TurnData ExecuteTurnInGameLoop(
            Table table, 
            IInputSelector inputSelector, 
            PlayerInputStateManager playerInputStateManager)
        {
            BeforeEventExecution?.Invoke(null, get_currentTurnNumber);

            TurnData turn = TurnExecutionRules.ExecuteTurn(
                get_currentTurnNumber,
                inputSelector,
                playerInputStateManager.get_currentSelectedInputState,
                table);

            AfterEventExecution?.Invoke(null, turn);

            get_currentTurnNumber++;

            return turn;
        }
    }
}