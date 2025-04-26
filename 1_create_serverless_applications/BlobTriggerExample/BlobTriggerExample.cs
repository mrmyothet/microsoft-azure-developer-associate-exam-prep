using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class BlobTriggerExample
    {
        private readonly ILogger<BlobTriggerExample> _logger;

        public BlobTriggerExample(ILogger<BlobTriggerExample> logger)
        {
            _logger = logger;
        }

        [Function(nameof(BlobTriggerExample))]
        public async Task Run([BlobTrigger("container1/{name}", Connection = "myothet")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
