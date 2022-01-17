const aws = require('aws-sdk');
const lambda = new aws.Lambda({
  maxRetries: 10,
  retryDelayOptions: {
    base: 1000
  }
});

const targets = process.env.TARGETS.split(',');
const warmer = process.env.AWS_LAMBDA_FUNCTION_NAME;

exports.handler = async () => {
  let result = await lambda.listFunctions().promise();
  let functions = [];
  while (true) {
    functions = functions.concat(
        result.Functions
          .filter(f => targets.some(x => f.FunctionName.startsWith(x)) && (f.FunctionName !== warmer))
          .map(f => lambda.invoke({ FunctionName: f.FunctionName, InvocationType: 'RequestResponse', Payload: JSON.stringify({ headers: { 'X-Lambda-Hot-Load': 'true' } }) }).promise()));
    if (!result.nextmarker) {
      break;
    }
    result = await lambda.listFunctions({ Marker: result.nextmarker }).promise();
  };

  await Promise.all(functions);
};
