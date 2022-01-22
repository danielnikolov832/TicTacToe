using TicTacToe.GameplayManagement.Rules.Input;

namespace ConsoleUI
{
    internal class InputSelector : IInputSelector
    {
        public virtual short SelectRow()
        {
            Console.WriteLine(globals_GameplayTexts.selectRowText);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectRow()
        {
            Console.WriteLine(globals_GameplayTexts.invalidInputText);
            
            return SelectRow();
        }

        public virtual short SelectColumn()
        {
            Console.WriteLine(globals_GameplayTexts.selectColumnText);

            return SelectTableCoordinate();
        }

        public virtual short RecoverOnFailedSelectColumn()
        {
            System.Console.WriteLine(globals_GameplayTexts.invalidInputText);
            
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