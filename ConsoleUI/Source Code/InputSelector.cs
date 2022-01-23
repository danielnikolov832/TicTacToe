using TicTacToe.GameplayManagement.Rules.Input;

namespace ConsoleUI
{
    internal class InputSelector : IInputSelector
    {
        private const string selectRowText = "Please enter a number between 1 and 3 to select a corresponding row";
        private const string selectColumnText = "Please enter a number between 1 and 3 to select a corresponding column";
        private const string invalidInputText = "Invalid input";

        public virtual short SelectRow()
        {
            Console.WriteLine(selectRowText);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectRow()
        {
            Console.WriteLine(invalidInputText);
            
            return SelectRow();
        }

        public virtual short SelectColumn()
        {
            Console.WriteLine(selectColumnText);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectColumn()
        {
            System.Console.WriteLine(invalidInputText);
            
            return SelectRow();
        }

        protected virtual short SelectTableCoordinate()
        {
            ConsoleKeyInfo currentKeyInfo = Console.ReadKey();
            Console.WriteLine(string.Empty);

            int rowOrColumn = (int)char.GetNumericValue(currentKeyInfo.KeyChar);

            return (short)rowOrColumn;
        }
    }
}