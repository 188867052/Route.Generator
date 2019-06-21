namespace UnitTest
{
    using Xunit.Abstractions;

    public class UnitTestBase
    {
        public UnitTestBase(ITestOutputHelper tempOutput)
        {
            this.Output = tempOutput;
        }

        protected ITestOutputHelper Output { get; set; }
    }
}
