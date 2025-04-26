using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TimeTrigger
{
    public class TimeTriggerExample
    {
        private readonly ILogger _logger;

        public TimeTriggerExample(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimeTriggerExample>();
        }

        [Function("TimeTriggerExample")]
        public void Run([TimerTrigger("0 */10 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
