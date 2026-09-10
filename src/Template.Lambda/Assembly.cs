[assembly: CLSCompliant(false)]

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Template.Lambda.Serialization.CustomLambdaJsonSerializer))]
