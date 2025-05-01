using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using StackExchange.Redis;
using Serilog;

namespace OrderProcessor;

public class OrderProcessor
{
    private readonly ILogger<OrderProcessor> _logger;

    public OrderProcessor(ILogger<OrderProcessor> logger)
    {
        _logger = logger;
    }

    [Function(nameof(OrderProcessor))]
    public void Run([QueueTrigger("incoming-orders", Connection = "")] QueueMessage message)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
    }

    [FunctionName("ProcessOrders")]
    public static void Processorders(
        [QueueTrigger("incoming-orders")] CloudQueueMessage myQueueItem, 
        ICollector<Order> tableBindings,
        TraceWriter log)
    {
        log.Info($"Processing Order: (myQueueItem.Id)");
        log.Info($"Queue Insertion Time: (myQueueItem.InsertionTime)");
        log.Info($"Queue Expiration Time: (myQueueItem.ExpirationTime)");
        tableBindings.Add(JsonConvert.DeserializeObject<Order>(myQueueItem.AsString));
    }
    [FunctionName("ProcessOrders - Poison")]
    public static void ProcessFailedORders([QueueTrigger("incoming - orders - poison")]CloudQueueMessage myQueueItem, TraceWriter Log)
     {
        Log.Error($"Failed to process order: (myQueueItem.AsString)");
    }
}
