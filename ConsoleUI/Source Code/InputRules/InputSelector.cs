using TicTacToe.GameplayManagement.Rules.Input;

using static ConsoleUI.ConsoleAddedMethods;

namespace ConsoleUI.InputRules
{
    internal class InputSelector : IInputSelector
    {
        private const string selectRowText = "Please enter a number between 1 and 3 to select a corresponding row";
        private const string selectColumnText = "Please enter a number between 1 and 3 to select a corresponding column";
        private const string invalidInputText = "Invalid input";

        public virtual short SelectRow()
        {
            WriteLineWithOptionalLining(selectRowText, true, false);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectRow()
        {
            WriteLineWithOptionalLining(invalidInputText, true, false);
            
            return SelectRow();
        }

        public virtual short SelectColumn()
        {
            WriteLineWithOptionalLining(selectColumnText, true, false);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectColumn()
        {
            WriteLineWithOptionalLining(invalidInputText, true, false);
            
            return SelectColumn();
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