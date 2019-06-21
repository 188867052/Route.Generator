namespace Route.Generator
{
    using McMaster.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Logging;

    public abstract class OptionsCommandBase : CommandBase
    {
        protected OptionsCommandBase(ILoggerFactory logger, IConsole console, IGeneratorOptionsSerializer serializer)
            : base(logger, console)
        {
            this.Serializer = serializer;
        }

        [Option("-p <project>", Description = "The project name")]
        public string ProjectName { get; set; }

        [Option("-u <baseaddress>", Description = "The base address")]
        public string BaseAddress { get; set; }

        [Option("-c <configjsonpath>", Description = "The json config path.")]
        public string ConfigJsonPath { get; set; }

        [Option("-f <file>", Description = "The options file name")]
        public string OptionsFile { get; set; }

        [Option("-o <output>", Description = "The out put file name")]
        public string OutPutFile { get; set; }

        protected IGeneratorOptionsSerializer Serializer { get; }

        protected CommondConfig Config { get; set; }
    }
}