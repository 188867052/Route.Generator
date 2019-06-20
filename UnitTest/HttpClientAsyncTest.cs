using Api.Routes;
using Core.Api.Framework;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest
{
    public class HttpClientAsyncTest : UnitTestBase
    {
        public HttpClientAsyncTest(ITestOutputHelper tempOutput) : base(tempOutput)
        {
            HttpClientAsync._output = tempOutput;
        }

        [Fact]
        public async Task Get_1_Constraint_1_ParamerAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await ValuesRoute.Get_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);
            string dataStr = data.ToString();

            this._output.WriteLine($"Response Data: {dataStr}");

            Assert.Contains(guid1, dataStr);
            Assert.Contains(guid2, dataStr);
        }

        [Fact]
        public async Task Get_1_Constraint_1_Paramer_Desc_Async()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await ValuesRoute.Get_1_Constraint_1_Parameter_DescAsync<dynamic>(guid1, guid2);

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
        [Theory(DisplayName = "测试特殊字符")]
        public async Task Get_Escape_Sequence_Async(string chars)
        {
            string guid1 = Guid.NewGuid().ToString() + chars;
            string guid2 = Guid.NewGuid().ToString() + chars;
            dynamic data = await ValuesRoute.Get_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);

            string dataStr = data.ToString();
            this._output.WriteLine($"Response Data: {dataStr}");
            Assert.Contains(guid1, dataStr);
            Assert.Contains(guid2, dataStr);
        }

        [InlineData("+")]
        [Theory(DisplayName = "双重转义序列异常")]
        public async Task Get_Escape_Sequence_Exception_Async(string chars)
        {
            await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                string guid1 = Guid.NewGuid().ToString() + chars;
                string guid2 = Guid.NewGuid().ToString() + chars;
                dynamic data = await ValuesRoute.Get_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);

                string dataStr = data.ToString();
                this._output.WriteLine($"Response Data: {dataStr}");
            });
        }

        [InlineData("\\")]
        [InlineData("/")]
        [Theory(DisplayName = "双重转义序列")]
        public async Task Get_1_Constraint_1_Paramer_Specima_Double_Escape_Sequence_Async(string chars)
        {
            string guid1 = Guid.NewGuid().ToString() + chars;
            string guid2 = Guid.NewGuid().ToString() + chars;
            dynamic data = await ValuesRoute.Get_1_Constraint_1_ParameterAsync<dynamic>(guid1, guid2);

            string dataStr = data.ToString();
            this._output.WriteLine($"Response Data: {dataStr}");
            Assert.DoesNotContain(guid1, dataStr);
            Assert.Contains(guid2, dataStr);
        }

        [InlineData("1", "2")]
        [Theory]
        public async Task Get_2_Constraints_0_ParameterAsync(string key, string value)
        {
            dynamic data = await ValuesRoute.Get_2_Constraints_0_ParameterAsync<dynamic>(key, value);
            string keyResponse = data.key;
            string valueResponse = data.value;

            Assert.Equal(key, keyResponse);
            Assert.Equal(value, valueResponse);
        }

        [Fact]
        public async Task Get_0_Constraint_0_ParamerterAsync()
        {
            dynamic data = await ValuesRoute.Get_0_Constraint_0_ParamerterAsync<dynamic>();
            string dataStr = data.ToString();

            this._output.WriteLine(dataStr);
            Assert.NotNull(dataStr);
        }

        [Fact]
        public async Task Get_0_Constraint_2_ParamerterAsync()
        {
            string guid = Guid.NewGuid().ToString();
            dynamic data = await ValuesRoute.Get_0_Constraint_2_ParamerterAsync<dynamic>(guid, "2");
            string dataStr = data.ToString();

            this._output.WriteLine(dataStr);
            Assert.Contains(guid, dataStr);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(123456)]
        public async Task Get_1_Nullable_ConstraintAsync(int? id)
        {
            dynamic data = await ValuesRoute.Get_1_Nullable_ConstraintAsync<dynamic>(id);
            int? idResponse = data.id;
            Assert.Equal(idResponse, id);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(null)]
        public async Task Get_1_Nullable_ParameterAsync(int? id)
        {
            dynamic data = await ValuesRoute.Get_1_Nullable_ParameterAsync<dynamic>(id);
            int? idResponse = data.id;
            Assert.Equal(idResponse, id);
        }
    }
}
