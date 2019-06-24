namespace UnitTest
{
    using System;
    using System.Threading.Tasks;
    using Api.Routes;
    using Xunit;
    using Xunit.Abstractions;

    public class HttpClientDeleteAsyncTest : UnitTestBase
    {
        public HttpClientDeleteAsyncTest(ITestOutputHelper tempOutput)
            : base(tempOutput)
        {
        }

        [Fact]
        public async Task Delete_5_Constraint_5_Parameter_None_OrderAsync()
        {
            string constraint4;
            string parameter5;
            string parameter3;
            string constraint1;
            string constraint5;
            string constraint2;
            string parameter1;
            string parameter2;
            string constraint3;
            string parameter4;

            dynamic data = await HttpDeleteRoute.Delete_5_Constraint_5_Parameter_None_OrderAsync<dynamic>(
                nameof(constraint4),
                nameof(parameter5),
                nameof(parameter3),
                nameof(constraint1),
                nameof(constraint5),
                nameof(constraint2),
                nameof(parameter1),
                nameof(parameter2),
                nameof(constraint3),
                nameof(parameter4));

            string constraint1Response = data.constraint1;
            string constraint2Response = data.constraint2;
            string constraint3Response = data.constraint3;
            string constraint4Response = data.constraint4;
            string constraint5Response = data.constraint5;
            string parameter1Response = data.parameter1;
            string parameter2Response = data.parameter2;
            string parameter3Response = data.parameter3;
            string parameter4Response = data.parameter4;
            string parameter5Response = data.parameter5;

            Assert.Equal(nameof(constraint1), constraint1Response);
            Assert.Equal(nameof(constraint2), constraint2Response);
            Assert.Equal(nameof(constraint3), constraint3Response);
            Assert.Equal(nameof(constraint4), constraint4Response);
            Assert.Equal(nameof(constraint5), constraint5Response);
            Assert.Equal(nameof(parameter1), parameter1Response);
            Assert.Equal(nameof(parameter2), parameter2Response);
            Assert.Equal(nameof(parameter3), parameter3Response);
            Assert.Equal(nameof(parameter4), parameter4Response);
            Assert.Equal(nameof(parameter5), parameter5Response);
        }

        [Fact]
        public async Task Delete_1_Constraint_1_ParamerAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpDeleteRoute.Delete_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);
            string dataStr = data.ToString();

            this.Output.WriteLine($"Response Data: {dataStr}");

            Assert.Contains(guid1, dataStr);
            Assert.Contains(guid2, dataStr);
        }

        [Fact]
        public async Task Delete_1_Constraint_1_Paramer_Desc_Async()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpDeleteRoute.Delete_1_Constraint_1_Parameter_DescAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [InlineData(".")]
        [InlineData("~")]
        [InlineData("?")]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("%")]
        [InlineData("^")]
        [InlineData("*")]
        [InlineData("&")]
        [InlineData("(")]
        [InlineData(")")]
        [InlineData("-")]
        [InlineData("_")]
        [InlineData("=")]
        [InlineData("{")]
        [InlineData("}")]
        [InlineData("<")]
        [InlineData(">")]
        [InlineData("|")]
        [InlineData("【")]
        [InlineData("】")]
        [InlineData("￥")]
        [InlineData("{}")]
        [InlineData("{{")]
        [InlineData("}}")]
        [InlineData("{id?}")]
        [InlineData("{{id?}}")]
        [InlineData("[controller]")]
        [InlineData("[action]")]
        [InlineData("api")]
        [InlineData("测试中文字符")]
        [InlineData("'")]
        [InlineData("[")]
        [InlineData("]")]
        [InlineData("\"")]
        [Theory(DisplayName = "Test Escape Sequence")]
        public async Task Delete_Escape_Sequence_Async(string chars)
        {
            string guid1 = Guid.NewGuid().ToString() + chars;
            string guid2 = Guid.NewGuid().ToString() + chars;
            dynamic data = await HttpDeleteRoute.Delete_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);
            string responseGuid1 = data.key;
            string responseGuid2 = data.value;

            Assert.Equal(guid1, responseGuid1);
            Assert.Equal(guid2, responseGuid2);
        }

        [InlineData("+")]
        [InlineData(" ")]
        [Theory(DisplayName = "Test Double Escape Sequence Exception")]
        public async Task Delete_Escape_Sequence_Exception_Async(string chars)
        {
            await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                string guid1 = Guid.NewGuid().ToString() + chars;
                string guid2 = Guid.NewGuid().ToString() + chars;
                dynamic data = await HttpDeleteRoute.Delete_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);

                string dataStr = data.ToString();
                this.Output.WriteLine($"Response Data: {dataStr}");
            });
        }

        [InlineData("\\")]
        [InlineData("/")]
        [Theory(DisplayName = "Test Double Escape Sequence ")]
        public async Task Delete_1_Constraint_1_Paramer_Specima_Double_Escape_Sequence_Async(string chars)
        {
            string guid1 = Guid.NewGuid().ToString() + chars;
            string guid2 = Guid.NewGuid().ToString() + chars;
            dynamic data = await HttpDeleteRoute.Delete_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);

            string dataStr = data.ToString();
            this.Output.WriteLine($"Response Data: {dataStr}");
            Assert.DoesNotContain(guid1, dataStr);
            Assert.Contains(guid2, dataStr);
        }

        [InlineData("1", "2")]
        [Theory]
        public async Task Delete_2_Constraints_0_ParameterAsync(string key, string value)
        {
            dynamic data = await HttpDeleteRoute.Delete_2_Constraints_0_ParameterAsync<dynamic>(key, value);
            string keyResponse = data.key;
            string valueResponse = data.value;

            Assert.Equal(key, keyResponse);
            Assert.Equal(value, valueResponse);
        }

        [Fact]
        public async Task Delete_0_Constraint_0_ParamerterAsync()
        {
            dynamic data = await HttpDeleteRoute.Delete_0_Constraint_0_ParamerterAsync<dynamic>();
            string dataStr = data.ToString();

            this.Output.WriteLine(dataStr);
            Assert.NotNull(dataStr);
        }

        [Fact]
        public async Task Delete_0_Constraint_2_ParamerterAsync()
        {
            string guid = Guid.NewGuid().ToString();
            dynamic data = await HttpDeleteRoute.Delete_0_Constraint_2_ParamerterAsync<dynamic>(guid, "2");
            string dataStr = data.ToString();

            this.Output.WriteLine(dataStr);
            Assert.Contains(guid, dataStr);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(123456)]
        public async Task Delete_1_Nullable_ConstraintAsync(int? id)
        {
            dynamic data = await HttpDeleteRoute.Delete_1_Nullable_ConstraintAsync<dynamic>(id);
            int? idResponse = data.id;
            Assert.Equal(idResponse, id);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(null)]
        public async Task Delete_1_Nullable_ParameterAsync(int? id)
        {
            dynamic data = await HttpDeleteRoute.Delete_1_Nullable_ParameterAsync<dynamic>(id);
            int? idResponse = data.id;
            Assert.Equal(idResponse, id);
        }
    }
}
