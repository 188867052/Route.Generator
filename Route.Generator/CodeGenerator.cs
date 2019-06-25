namespace Route.Generator
{
    using System;
    using System.IO;

    public class CodeGenerator : ICodeGenerator
    {
        private readonly RouteGenerator modelGenerator;

        public CodeGenerator()
        {
            this.modelGenerator = new RouteGenerator();
        }

        public bool Generate(CommondConfig config)
        {
            var context = this.modelGenerator.GenerateCodeAsync(config).Result;
            if (string.IsNullOrEmpty(context))
            {
                return false;
            }

            Console.WriteLine(context);

            string fullPath = Path.Combine(config.ProjectPath, config.OutPutFile);

            Console.WriteLine($"Writing file to {fullPath}...");
            File.WriteAllText(fullPath, context);
            Console.WriteLine("Completed.");

            return true;
        }
    }
}
