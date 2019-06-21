﻿using Api.Models;
using Api.Routes;
using Core.Api.Framework;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest
{
    public class HttpClientPostAsyncTest : UnitTestBase
    {
        public HttpClientPostAsyncTest(ITestOutputHelper tempOutput) : base(tempOutput)
        {
            HttpClientAsync._output = tempOutput;
        }

        [Fact]
        public async Task Post_1_FromBody_1_ConstraintAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPostRoute.Post_1_FromBody_1_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [Fact]
        public async Task Post_2_Constraint_ParasAsync()
        {
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = Guid.NewGuid().ToString();
            dynamic data = await HttpPostRoute.Post_2_ConstraintAsync<dynamic>(guid1, guid2);

            string key = data.key;
            string value = data.value;

            Assert.Equal(guid1, key);
            Assert.Equal(guid2, value);
        }

        [Fact]
        public async Task Post_1_FromBody()
        {
            string guid1 = Guid.NewGuid().ToString();
            dynamic data = await HttpPostRoute.Post_1_FromBodyAsync<dynamic>(guid1);

            string key = data.key;

            Assert.Equal(guid1, key);
        }

        [Theory]
        [InlineData(66, 88)]
        public async Task Post_Model(int x, int y)
        {
            PointModel point = new PointModel { X = x, Y = y };
            dynamic data = await HttpPostRoute.Post_ModelAsync<dynamic>(point);

            int xResponse = data.x;
            int yResponse = data.y;

            Assert.Equal(x, xResponse);
            Assert.Equal(y, yResponse);
        }
    }
}
