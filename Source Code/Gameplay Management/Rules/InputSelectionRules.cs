using System;

namespace TicTacToe.GameplayManagement.Rules
{
    // Defines the rules on how the player/s can select input
    public static class InputSelectionRules
    {
        private static readonly object __lockObj = new object();

        private static ConsoleKey gameExitKey = ConsoleKey.Escape;
        public static ConsoleKey GameExitKey
        {
            get => gameExitKey;

            set
            {
                lock(__lockObj)
                {
                    gameExitKey = value;
                }
            }
        }

        public static int SelectRow()
        {
            Console.WriteLine(globals_GameplayTexts.selectRowText);

            return SelectTableCoordinate();
        }

        public static int SelectColumn()
        {
            Console.WriteLine(globals_GameplayTexts.selectColumnText);

            return SelectTableCoordinate();
        }

        private static int SelectTableCoordinate()
        {
            ConsoleKeyInfo currentKeyInfo = Console.ReadKey();
            Console.WriteLine(string.Empty);

            int rowOrColumn = (int)char.GetNumericValue(currentKeyInfo.KeyChar);

            if (rowOrColumn < 1 || rowOrColumn > 3)
            {
                Console.WriteLine($"\n{globals_GameplayTexts.invalidInputText}\n");
                
                return SelectTableCoordinate();
            }

            return rowOrColumn;
        }

        public static TableElementStates SelectXOrO()
        {
            Console.WriteLine(globals_GameplayTexts.selectXOrOText);

            TableElementStates output;

            ConsoleKeyInfo currentKeyInfo = Console.ReadKey();
            
            Console.WriteLine(); 

            if (currentKeyInfo.Key == ConsoleKey.X)
            {
                output = TableElementStates.X;
            }
            else if (currentKeyInfo.Key == ConsoleKey.O)
            {
                output = TableElementStates.O;
            }
            else
            {
                Console.WriteLine($"\n{globals_GameplayTexts.invalidInputText}\n");
                return SelectXOrO();
            }

            return output;
        }

    }
}