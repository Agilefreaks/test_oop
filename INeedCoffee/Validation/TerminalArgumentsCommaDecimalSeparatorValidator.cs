using System;
namespace INeedCoffee
{
    public static class TerminalArgumentsCommaDecimalSeparatorValidator
    {
        public static void Validate(string[] terminalArguments)
        {
            if (terminalArguments[0].Contains(","))
            {
                terminalArguments[0] = terminalArguments[0].Replace(",", ".");
            }

            if (terminalArguments[1].Contains(","))
            {
                terminalArguments[1] = terminalArguments[1].Replace(",", ".");
            }
        }
    }
}
