#pragma warning disable CS8669
namespace Template.Lambda.Functions
{
    public sealed class CrudFunction_List2
    {
        private readonly Template.Lambda.HttpApiServiceResolver serviceResolver;

        private readonly Template.Lambda.HttpApiFilter filter;

        private readonly AmazonLambdaExtension.Serialization.IBodySerializer serializer;

        private readonly Template.Lambda.Functions.CrudFunction function;

        public CrudFunction_List2()
        {
            serviceResolver = new Template.Lambda.HttpApiServiceResolver();
            filter = new Template.Lambda.HttpApiFilter();
            serializer = serviceResolver.GetService<AmazonLambdaExtension.Serialization.IBodySerializer>() ?? AmazonLambdaExtension.Serialization.JsonBodySerializer.Default;
            function = new Template.Lambda.Functions.CrudFunction(serviceResolver.GetService<Microsoft.Extensions.Logging.ILogger<Template.Lambda.Functions.CrudFunction>>(),serviceResolver.GetService<AutoMapper.IMapper>(),serviceResolver.GetService<Template.Services.DataService>());
        }

        public async System.Threading.Tasks.Task<Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse> Handle(Amazon.Lambda.APIGatewayEvents.APIGatewayProxyRequest request, Amazon.Lambda.Core.ILambdaContext context)
        {
            var executingResult = filter.OnFunctionExecuting(request, context);
            if (executingResult != null)
            {
                return executingResult;
            }

            try
            {
                if (!AmazonLambdaExtension.Helpers.BindHelper.TryBind<string?>(request.QueryStringParameters, "token", out var p0))
                {
                    return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 400 };
                }

                var output = await function.List(p0).ConfigureAwait(false);
                if (output == null)
                {
                    return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 404 };
                }

                return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse
                {
                    Body = serializer.Serialize(output),
                    Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } },
                    StatusCode = 200
                };
            }
            catch (AmazonLambdaExtension.ApiException ex)
            {
                return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = ex.StatusCode };
            }
            catch (System.Exception ex)
            {
                context.Logger.LogLine(ex.ToString());
                return new Amazon.Lambda.APIGatewayEvents.APIGatewayProxyResponse { StatusCode = 500 };
            }
            finally
            {
                filter.OnFunctionExecuted(request, context);
            }
        }
    }
}
