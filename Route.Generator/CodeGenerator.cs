using System;
using System.IO;

namespace Route.Generator
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly RouteGenerator _modelGenerator;

        public CodeGenerator()
        {
            this._modelGenerator = new RouteGenerator();
        }

        public bool Generate(CommondConfig config)
        {
            var context = this._modelGenerator.GenerateCodeAsync(config).Result;
            Console.WriteLine(context);

            string fullPath = Path.Combine(Environment.CurrentDirectory, config.OutPutFile);
            File.WriteAllText(fullPath, context);
            return true;
        }
    }
}
