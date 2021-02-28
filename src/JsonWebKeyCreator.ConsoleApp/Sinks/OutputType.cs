using System;

namespace RW7.DotNetSecurityTools.JsonWebKeyCreator.ConsoleApp.Sinks
{
    [Flags]
    public enum OutputType
    {
        Console = 0,

        File = 1
    }
}