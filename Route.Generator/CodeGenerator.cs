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
            Console.WriteLine(context);

            string fullPath = Path.Combine(Environment.CurrentDirectory, config.OutPutFile);
            File.WriteAllText(fullPath, context);
            return true;
        }
    }
}
