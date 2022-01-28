namespace ConsoleUI
{
    internal static class ConsoleAddedMethods
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