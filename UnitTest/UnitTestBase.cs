using Xunit.Abstractions;

namespace UnitTest
{
    public class UnitTestBase
    {
        protected readonly ITestOutputHelper _output;

        public UnitTestBase(ITestOutputHelper tempOutput)
        {
            this._output = tempOutput;
        }

    }
}
