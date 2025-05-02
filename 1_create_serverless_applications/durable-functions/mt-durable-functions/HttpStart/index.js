const { app } = require('@azure/functions');
const df = require('durable-functions');

app.http('HttpStart', {
  route: 'orchestrators/OrchFunction',
  extraInputs: [df.input.durableClient()],
  handler: async (_request, context) => {
    const client = df.getClient(context)
    const status = await client.getStatus('instanceId', {
      showHistory: false,
      showHistoryOutput: false,
      showInput: true
    });
  },
});