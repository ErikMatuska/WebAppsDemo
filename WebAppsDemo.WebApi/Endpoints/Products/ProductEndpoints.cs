namespace WebAppsDemo.WebApi.Endpoints.Products
{
    public static class ProductEndpoints
    {
        public static void AddProductEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("/test", () => TypedResults.Ok("test"));
        }
    }
}
