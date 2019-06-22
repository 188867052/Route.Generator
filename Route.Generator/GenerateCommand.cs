﻿namespace Route.Generator
{
    using System.IO;
    using System.Linq;
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
            try
            {
                this.ConfigJsonPath = Directory.GetFiles(".", "appsettings.json", SearchOption.AllDirectories).FirstOrDefault();
                if (string.IsNullOrEmpty(this.ConfigJsonPath))
                {
                    this.Console.WriteLine("No appsettings.json file found, will generate code with default setting.");
                }

                string appSettings = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(this.ConfigJsonPath)).RouteGenerator.ToString();
                CommondConfig config = JsonConvert.DeserializeObject<CommondConfig>(appSettings);
                this.Config = config;
                this.Console.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));
                if (string.IsNullOrEmpty(this.Config.BaseAddress))
                {
                    this.Console.WriteLine($"base address cant not be null.");
                    return 1;
                }

                if (string.IsNullOrEmpty(this.Config.OutPutFile))
                {
                    this.Config.OutPutFile = "Routes.Generated.cs";
                }

                if (!this.Config.OutPutFile.EndsWith(".cs"))
                {
                    this.Config.OutPutFile += ".cs";
                }
            }
            catch (System.Exception ex)
            {
                this.Console.WriteLine("Read config file error.");
                this.Console.WriteLine(ex.Message);
                this.Console.WriteLine(ex.StackTrace);
                return 1;
            }

            return 0;
        }
    }
}