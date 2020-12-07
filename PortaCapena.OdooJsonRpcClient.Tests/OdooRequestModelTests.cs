﻿using System.Collections.Generic;
using FluentAssertions;
using PortaCapena.OdooJsonRpcClient.Request;
using Xunit;

namespace PortaCapena.OdooJsonRpcClient.Tests
{
    public class OdooRequestModelTests : TestBase
    {
        [Fact]
        public void CreateRequestModel_should_return_request_with_corect_params_count()
        {
            var query = new OdooQuery()
            {
                ReturnFields = new HashSet<string> { "name" },
                Filters = new OdooFilter { new object[] { "id", "=", 66 } }
            };
            var request = OdooRequestModel.SearchRead(_config, 2, "table", query);
            request.Params.Args.Length.Should().Be(7);


            var query2 = new OdooQuery(){Filters = new OdooFilter{ new object[] { "id", "=", 66 } }};
            var request2 = OdooRequestModel.SearchRead(_config, 2, "table", query2);
            request2.Params.Args.Length.Should().Be(6);


            var query3 = new OdooQuery(){ReturnFields = new HashSet<string> { "name" }};
            var request3 = OdooRequestModel.SearchRead(_config, 2, "table", query3);
            request3.Params.Args.Length.Should().Be(7);


            var request4 = OdooRequestModel.SearchRead(_config, 2, "table");
            request4.Params.Args.Length.Should().Be(5);


            var query5 = new OdooQuery(){Skip = 10};
            var request5 = OdooRequestModel.SearchRead(_config, 2, "table", query5);
            request5.Params.Args.Length.Should().Be(8);


            var query6 = new OdooQuery() { Take = 10 };
            var request6 = OdooRequestModel.SearchRead(_config, 2, "table", query6);
            request6.Params.Args.Length.Should().Be(9);


            var query7 = new OdooQuery() { Order = "id" };
            var request7 = OdooRequestModel.SearchRead(_config, 2, "table", query7);
            request7.Params.Args.Length.Should().Be(10);


            var queryTest = new OdooQuery()
            {
                ReturnFields = new HashSet<string> { "name" },
                Filters = OdooFilter.Create().Equal("id", 66)
            };

            var requestTest = OdooRequestModel.SearchRead(_config, 2, "table", queryTest);
            requestTest.Params.Args.Length.Should().Be(7);
        }
    }
}