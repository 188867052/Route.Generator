namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Routes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Routing.Patterns;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using Xunit.Abstractions;

    public class HttpClientPutAsyncTest : UnitTestBase
    {
        public HttpClientPutAsyncTest(ITestOutputHelper tempOutput)
            : base(tempOutput)
        {
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
