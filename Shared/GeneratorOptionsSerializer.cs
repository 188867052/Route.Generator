namespace Route.Generator
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Logging;

    public interface IGeneratorOptionsSerializer
    {
        string Save(string directory);
    }

    /// <summary>
    /// Serialization and Deserialization for the <see cref="GeneratorOptions"/> class.
    /// </summary>
    public class GeneratorOptionsSerializer : IGeneratorOptionsSerializer
    {
        private readonly ILogger<GeneratorOptionsSerializer> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratorOptionsSerializer"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GeneratorOptionsSerializer(ILogger<GeneratorOptionsSerializer> logger)
        {
            this.logger = logger;
        }

        public string Save(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = Environment.CurrentDirectory;
            }

            if (!Directory.Exists(directory))
            {
                this.logger.LogTrace($"Creating Directory: {directory}");
                Directory.CreateDirectory(directory);
            }

            return string.Empty;
        }
    }
}
