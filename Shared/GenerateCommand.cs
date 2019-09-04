namespace Route.Generator
{
    using System;
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
                CommondConfig config = new CommondConfig();

                // From console.
                if (!string.IsNullOrEmpty(this.ProjectName))
                {
                    string fileFullPath = Directory.GetFiles(".", $"{this.ProjectName}.csproj", SearchOption.AllDirectories).FirstOrDefault();
                    if (string.IsNullOrEmpty(fileFullPath))
                    {
                        System.Console.Write($"Project {this.ProjectName} is not exist.");
                        return 1;
                    }

                    config.ProjectPath = new FileInfo(fileFullPath).DirectoryName;
                    config.ProjectName = this.ProjectName;
                    config.GenerateMethod = this.GenerateMethod == "1" || this.GenerateMethod.Equals("true", StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    // From appsettings.json.
                    this.ConfigJsonPath = Directory.GetFiles(".", "appsettings.json", SearchOption.AllDirectories).FirstOrDefault();
                    if (string.IsNullOrEmpty(this.ConfigJsonPath))
                    {
                        this.Console.WriteLine("No appsettings.json file found, will generate code with default setting.");
                    }

                    string appSettings = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(this.ConfigJsonPath)).RouteGenerator.ToString();
                    config = JsonConvert.DeserializeObject<CommondConfig>(appSettings);
                    if (string.IsNullOrEmpty(config.ProjectName))
                    {
                        System.Console.Write($"Please provide ProjectName.");
                        return 1;
                    }

                    string fileFullPath = Directory.GetFiles(".", $"{config.ProjectName}.csproj", SearchOption.AllDirectories).FirstOrDefault();
                    if (string.IsNullOrEmpty(fileFullPath))
                    {
                        System.Console.Write($"Project {config.ProjectName} is not exist.");
                        return 1;
                    }

                    config.ProjectPath = new FileInfo(fileFullPath).DirectoryName;
                }

                this.Config = config;
                this.Console.WriteLine(JsonConvert.SerializeObject(config, Formatting.Indented));

                if (string.IsNullOrEmpty(this.Config.OutPutFile))
                {
                    this.Config.OutPutFile = "Routes.Generated.cs";
                }

                if (!this.Config.OutPutFile.EndsWith(".cs"))
                {
                    this.Config.OutPutFile += ".cs";
                }

                if (string.IsNullOrEmpty(this.Config.ProjectName))
                {
                    this.Console.WriteLine($"Please provide ProjectName.");
                    return 1;
                }
            }
            catch (Exception ex)
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
