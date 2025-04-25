using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTriggerExample
    {
        private readonly ILogger<HttpTriggerExample> _logger;

        public HttpTriggerExample(ILogger<HttpTriggerExample> logger)
        {
            _logger = logger;
        }

        [Function("HttpTriggerExample")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
