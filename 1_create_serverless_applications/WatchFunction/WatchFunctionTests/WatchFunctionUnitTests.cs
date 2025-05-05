namespace WatchFunctionTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Http.Internal;

public class WatchFunctionUnitTests
{
    [Fact]
    public void TestWatchFunctionSuccess()
    {
        var queryStringValue = "abc";

        var httpContext = new DefaultHttpContext();
        var request = httpContext.Request;
        request.Query = new QueryCollection
            (
                new System.Collections.Generic.Dictionary<string, StringValues>()
                {
        { "model", queryStringValue }
                }
            );

        var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        var response = WatchFunction.WatchInfo.Run(request, logger);
        response.Wait();

        // Check that the response is an "OK" response
        Assert.IsAssignableFrom<OkObjectResult>(response.Result);

        // Check that the contents of the response are the expected contents
        var result = (OkObjectResult)response.Result;
        dynamic watchinfo = new { Manufacturer = "abc", CaseType = "Solid", Bezel = "Titanium", Dial = "Roman", CaseFinish = "Silver", Jewels = 15 };
        string watchInfo = $"Watch Details: {watchinfo.Manufacturer}, {watchinfo.CaseType}, {watchinfo.Bezel}, {watchinfo.Dial}, {watchinfo.CaseFinish}, {watchinfo.Jewels}";
        Assert.Equal(watchInfo, result.Value);
    }

    [Fact]
    public void TestWatchFunctionFailureNoQueryString()
    {
        var httpContext = new DefaultHttpContext();
        var request = httpContext.Request;

        var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        var response = WatchFunction.WatchInfo.Run(request, logger);
        response.Wait();

        // Check that the response is an "Bad" response
        Assert.IsAssignableFrom<BadRequestObjectResult>(response.Result);

        // Check that the contents of the response are the expected contents
        var result = (BadRequestObjectResult)response.Result;
        Assert.Equal("Please provide a watch model in the query string", result.Value);
    }

    [Fact]
    public void TestWatchFunctionFailureNoModel()
    {
        var queryStringValue = "abc";
        var httpContext = new DefaultHttpContext();
        var request = httpContext.Request;
        request.Query = new QueryCollection
            (
                new System.Collections.Generic.Dictionary<string, StringValues>()
                {
                { "not-model", queryStringValue }
                }
            );

        var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        var response = WatchFunction.WatchInfo.Run(request, logger);
        response.Wait();

        // Check that the response is an "Bad" response
        Assert.IsAssignableFrom<BadRequestObjectResult>(response.Result);

        // Check that the contents of the response are the expected contents
        var result = (BadRequestObjectResult)response.Result;
        Assert.Equal("Please provide a watch model in the query string", result.Value);
    }
}