namespace Route.Generator
{
    using System.IO;
    using McMaster.Extensions.CommandLineUtils;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    [Command("generate", "gen")]
    public class GenerateCommand : OptionsCommandBase
    {
        private readonly ICodeGenerator codeGenerator;

        public GenerateCommand(ILoggerFactory logger, IConsole console, IGeneratorOptionsSerializer serializer, ICodeGenerator codeGenerator)
            : base(logger, console, serializer)
        {
            this.codeGenerator = codeGenerator;
        }

        protected override int OnExecute(CommandLineApplication application)
        {
            if (this.Initialize() != 0)
            {
                return 1;
            }

            var result = this.codeGenerator.Generate(this.Config);

            return result ? 0 : 1;
        }

        private int Initialize()
        {
            FileInfo info = new FileInfo(this.ConfigJsonPath);
            if (!info.Exists)
            {
                this.Console.WriteLine($"config json path: {this.ConfigJsonPath} can not be found.");
                return 1;
            }

            var config = JsonConvert.DeserializeObject<CommondConfig>(File.ReadAllText(this.ConfigJsonPath));
            this.Console.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));
            if (string.IsNullOrEmpty(config.BaseAddress))
            {
                this.Console.WriteLine($"base address cant not be null.");
                return 1;
            }

            if (string.IsNullOrEmpty(config.OutPutFile))
            {
                config.OutPutFile = "Routes.Generated.cs";
            }

            if (!config.OutPutFile.EndsWith(".cs"))
            {
                config.OutPutFile += ".cs";
            }

            this.Config = config;
            return 0;
        }
    }
}
