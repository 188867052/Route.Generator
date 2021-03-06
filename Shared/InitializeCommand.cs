﻿namespace Route.Generator
{
    using McMaster.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Logging;

    [Command("initialize", "init")]
    public class InitializeCommand : OptionsCommandBase
    {
        public InitializeCommand(ILoggerFactory logger, IConsole console, IGeneratorOptionsSerializer serializer)
            : base(logger, console, serializer)
        {
        }

        protected override int OnExecute(CommandLineApplication application)
        {
            return 0;
        }
    }
}