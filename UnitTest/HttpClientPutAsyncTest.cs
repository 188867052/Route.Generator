namespace UnitTest
{
    using System;
    using System.Threading.Tasks;
    using Api.Routes;
    using Core.Api.Framework;
    using Xunit;
    using Xunit.Abstractions;

    public class HttpClientPutAsyncTest : UnitTestBase
    {
        public HttpClientPutAsyncTest(ITestOutputHelper tempOutput)
            : base(tempOutput)
        {
            HttpClientAsync.Output = tempOutput;
        }

        [Fact]
        public async Task Put_1_FromBody_1_ConstraintAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPutRoute.Put_1_FromBody_1_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [Fact]
        public async Task Put_2_Constraint_ParasAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPutRoute.Put_2_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }
    }
}
