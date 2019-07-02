using System.Collections.Generic;

namespace DependencyInjection.Analyzer
{
    public interface IDependencyInjectionAnalyzer
    {
        IEnumerable<DependencyInjectionInfo> GetDependencyInjectionInfo();
    }
}
