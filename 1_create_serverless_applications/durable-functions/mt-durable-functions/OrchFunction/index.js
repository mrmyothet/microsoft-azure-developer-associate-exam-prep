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

const df = require("durable-functions");

module.exports = df.orchestrator(function* (context) {
  const outputs = [];

  /*
  * We will call the approval activity with a reject and an approved to simulate both
  */

  outputs.push(yield context.df.callActivity("Approval", "Approved"));
  outputs.push(yield context.df.callActivity("Approval", "Rejected"));

  return outputs;
});