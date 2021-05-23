using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        const int ReverseCommand = 16;

        Func<int,bool> isCode = (commandToEvaluate) => (commandValue & commandToEvaluate) > 0;

        Dictionary<int, string> handshake = new Dictionary<int, string>
        {
            { 1, "wink" },
            { 2, "double blink" },
            { 4, "close your eyes" },
            { 8, "jump"}
        };

        var commands = handshake.Keys.Where(code => isCode(code))
                                     .Select(code => handshake[code]);

        return isCode(ReverseCommand) ? commands.Reverse().ToArray() : commands.ToArray();
    }
}
