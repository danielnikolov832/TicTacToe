namespace ConsoleUI
{
    // Defines the static methods to make console spacing easier to implement
    internal static class ConsoleSpacingMethods
    {
        internal static void WriteLineWithOptionalLining(object? obj, bool willHaveEmptyLineBefore, bool willHaveEmptyLineAfter)
        {
            if (willHaveEmptyLineBefore)
            {
                Console.WriteLine();
            }

            Console.WriteLine(obj);

            if (willHaveEmptyLineAfter)
            {
                Console.WriteLine();
            }
        }
    }
}