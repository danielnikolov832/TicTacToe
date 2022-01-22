using System;
using TicTacToe.GameDataManagement;

namespace ConsoleUI
{
    // Stores globally used text for the gameplay
    public static class globals_GameplayTexts
    {
        public const string introductoryText = "Hi, ready for some good old TicTacToe";
        public const string winText = "We won";

        public const string pressAnyKeyToContinueText = "Press any key to continue";
        public const string pressAnyKeyToExitText = "Press any key to exit";

        public const string selectRowText = "Please enter a number between 1 and 3 to select a corresponding row";
        public const string selectColumnText = "Please enter a number between 1 and 3 to select a corresponding column";

        public const string invalidInputText = "Invalid input";
        public const string unsuccessfulAssignmentText = "Element was not assigned successfully, try different coordinates";
    }
}