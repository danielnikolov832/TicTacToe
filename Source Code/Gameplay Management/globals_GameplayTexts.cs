using System;
using TicTacToe.GameDataManagement;

namespace TicTacToe.GameplayManagement
{
    // Stores globally used text for the gameplay
    public static class globals_GameplayTexts
    {
        public const string introductoryText = "Hi, ready for some good old TicTacToe";
        public const string winText = "We won";

        public static string pressAnyKeyToContinueText = "Press any key to continue";
        public static string pressAnyKeyToExitText = "Press any key to exit";

        public const string selectRowText = "Please enter a number between 1 and 3 to select a corresponding row";
        public const string selectColumnText = "Please enter a number between 1 and 3 to select a corresponding column";
        public const string notValidElementStateText = "currentSelectedInputState is not valid";
            

        public const string invalidInputText = "Invalid input";
        public const string alreadyAssignedText = "This element has already been assigned, try different coordinates";

        public const string X = "X";
        public const string O = "O";
        public const string Unchecked = " ";

        public const string noChangeOccuredText = "No change occured";

        public static string GetLastRecordedChangeText(
            bool isChanged, int indexForDimension0, int indexForDimension1, TableElementStates newElement)
        {
            if (isChanged == false)
            {
                return globals_GameplayTexts.noChangeOccuredText;
            }

            return $"Changed element at [{indexForDimension0 + 1}, {indexForDimension1 + 1}] to " + 
            $"{TableDisplayProvider.GetTableElementAsString(newElement)}";
        }
    }
}