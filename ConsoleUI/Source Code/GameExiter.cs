using TicTacToe.GameplayManagement.GameExecution;

namespace ConsoleUI
{
    internal sealed class GameExiter : IGameExiter
    {
        internal GameExiter(ConsoleKey gameExitKey)
        {
            _gameExitKey = gameExitKey;
        }

        private ConsoleKey _gameExitKey;
        public ConsoleKey getset_gameExitKey {get => _gameExitKey; set => _gameExitKey = value; }

        public bool WillExitGameImmediately()
        {
            throw new NotImplementedException("Not implemented method");
        }

        public bool WillExitGameOnBeginTurnExecution()
        {
            return Console.ReadKey(true).Key == _gameExitKey;
        }
    }
}