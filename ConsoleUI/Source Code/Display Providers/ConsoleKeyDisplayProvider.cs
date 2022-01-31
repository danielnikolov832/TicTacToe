namespace ConsoleUI.DisplayProviers
{
    internal static class ConsoleKeyDisplayProvider
    {
        internal static string GetConsoleKeyAsString(ConsoleKey consoleKey)
        {
            string? enumName = typeof(ConsoleKey).GetEnumName((int)consoleKey);

            if (enumName == null) return string.Empty;

            string output = enumName;

            if (output.Length == 2 && output.StartsWith("D"))
            {
                output = output.Substring(1, 1);
            }

            return output;
        }
    }
}