namespace UnitTest
{
    using System;
    using System.Threading.Tasks;
    using Api.Models;
    using Api.Routes;
    using Xunit;
    using Xunit.Abstractions;

    public class HttpClientPatchAsyncTest : UnitTestBase
    {
        public HttpClientPatchAsyncTest(ITestOutputHelper tempOutput)
            : base(tempOutput)
        {
        }

        [Fact]
        public async Task Patch_1_FromBody_1_ConstraintAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPatchRoute.Patch_1_FromBody_1_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [Fact]
        public async Task Patch_2_Constraint_ParasAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPatchRoute.Patch_2_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [Fact]
        public async Task Patch_1_FromBody()
        {
            string guid1 = Guid.NewGuid().ToString();
            dynamic data = await HttpPatchRoute.Patch_1_FromBodyAsync<dynamic>(guid1);

            string key = data.key;

            Assert.Equal(guid1, key);
        }

        [Theory]
        [InlineData(66, 88)]
        public async Task Patch_Model(int x, int y)
        {
            PointModel point = new PointModel { X = x, Y = y };
            dynamic data = await HttpPatchRoute.Patch_ModelAsync<dynamic>(point);

            int xResponse = data.x;
            int yResponse = data.y;

            Assert.Equal(x, xResponse);
            Assert.Equal(y, yResponse);
        }
    }
}
