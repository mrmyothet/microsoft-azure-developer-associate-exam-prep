/*
* This function is not intended to be invoked directly. Instead it will be
* triggered by an HTTP starter function.
* 
* Before running this sample, please:
* - create a Durable activity function (default name is "Hello")
* - create a Durable HTTP starter function
* - run 'npm install durable-functions' from the wwwroot folder of your 
*    function app in Kudu
*/

const df = require('durable-functions');
const moment = require("moment");

const activityName = 'Hello';

df.app.orchestration('durableOrchestrator', function* (context) {
  const outputs = [];
  outputs.push(yield context.df.callActivity(activityName, 'Tokyo'));
  outputs.push(yield context.df.callActivity(activityName, 'Seattle'));
  outputs.push(yield context.df.callActivity(activityName, 'Cairo'));

  return outputs;
});


// module.exports = df.orchestrator(function* (context) {
//   const outputs = [];
//   const deadline = moment.utc(context.df.currentUtcDateTime).add(20, "s");
//   const activityTask = context.df.waitForExternalEvent("Approval");
//   const timeoutTask = context.df.createTimer(deadline.toDate());

//   const winner = yield context.df.Task.any([activityTask, timeoutTask]);
//   if (winner === activityTask) {
//     outputs.push(yield context.df.callActivity("Approval", "Approved"));
//   }
//   else {
//     outputs.push(yield context.df.callActivity("Escalation", "Head of department"));
//   }

//   if (!timeoutTask.isCompleted) {
//     // All pending timers must be complete or canceled before the function exits.
//     timeoutTask.cancel();
//   }

//   return outputs;
// });