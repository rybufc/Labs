using System;
using System.Collections.Generic;

namespace GraphicsEditor.Commands
{
    public static class CommandsHelpers
    {

        public static bool TryParseArgs(string[] args, int i, List<string> exceptions, string parameter, out float tmp,
            ref bool parseSuccess)
        {
            bool parseResult = Single.TryParse(args[i], out tmp);
            if (!parseResult)
            {
                exceptions.Add($"Параметр '{parameter}' - не является числом типа float");
                parseSuccess = false;
                return true;
            }
            return false;
        }

        public static void WriteErrorMessages(List<string> exceptions)
        {
            foreach (var exceptionMessage in exceptions)
            {
                Console.WriteLine(exceptionMessage);
            }
        }

        public static bool CheckForPresenceInRange(float tmp, List<string> exceptions, string parameter, ref bool parseSuccess)
        {
            if (tmp > 1000000)
            {
                exceptions.Add($"Параметр '{parameter}' - слишком большой.");
                parseSuccess = false;
                return true;
            }
            if (tmp < -1000000)
            {
                exceptions.Add($"Параметр '{parameter}' - слишком маленький.");
                parseSuccess = false;
                return true;
            }
            return false;
        }
    }
}
