using System;

namespace TicTacToe.GameplayManagement.Rules.Input
{
    // Defines the rules on how the player/s can select input
    public static class TableCoordinateSelectionRules
    {
        internal static (short indexForDimension0, short indexForDimension1) GetCoordinatesFromRowAndColumnInInputSelector(
            IInputSelector inputSelector)
        {
            (short rowNum, short columnNum) = GetRowAndColumn(inputSelector);

            (short indexForDimension0, short indexForDimension1) = 
            ConvertRowAndColumnToCoordinates(rowNum, columnNum);

            return (indexForDimension0, indexForDimension1);
        }

        private static (short indexForDimension0, short indexForDimension1) ConvertRowAndColumnToCoordinates(
            short rowNum,
            short columnNum)
        {
            short indexForDimension0 = (short)((int)rowNum - 1);
            short indexForDimension1 = (short)((int)columnNum - 1);

            return (indexForDimension0, indexForDimension1);
        }

        internal static (short rowNum, short columnNum) GetRowAndColumn(
            IInputSelector inputSelector)
        {
            short rowNum = GetRow(inputSelector);
            short columnNum = GetColumn(inputSelector);

            return (rowNum, columnNum);
        }

        internal static short GetRow(IInputSelector inputSelector)
        {
            return GetValidTableCoordinate(inputSelector.SelectRow, inputSelector.RecoverOnFailedSelectRow);
        }

        internal static short GetColumn(IInputSelector inputSelector)
        {
            return GetValidTableCoordinate(inputSelector.SelectColumn, inputSelector.RecoverOnFailedSelectColumn);
        }

        private static short GetValidTableCoordinate(Func<short> selectMethod, Func<short> recoverOnSelectFailedMethod)
        {
            short rowOrColumnNum = selectMethod.Invoke();

            if (ValidateTableCoordinate(rowOrColumnNum) == false)
            {
                return RecurInputSelectionMethodCall(recoverOnSelectFailedMethod);
            }

            return rowOrColumnNum;
        }

        private static short RecurInputSelectionMethodCall(Func<short> methodToRecur)
        {
            short rowNumFromRecover = methodToRecur.Invoke();

            if (ValidateTableCoordinate(rowNumFromRecover) == false)
            {
                return RecurInputSelectionMethodCall(methodToRecur);
            }

            return rowNumFromRecover;
        }

        private static bool ValidateTableCoordinate(short rowOrColumnNum)
        {
            if (rowOrColumnNum < 1 || rowOrColumnNum > 3) return false;

            return true;
        }
    }
}