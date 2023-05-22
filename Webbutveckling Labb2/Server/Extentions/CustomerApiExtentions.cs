namespace Webbutveckling_Labb2.Server.Extentions
{
    public static class CustomerApiExtentions
    {
        public static IServiceCollection UseCustomerApi(this IServiceCollection service)
        {
            service.AddScoped<ICustomerService, CustomerService>();
            return service;
        }

        public static WebApplication MapCustomerEndpoints(this WebApplication app)
        {
            app.MediateGet<GetCustomerRequest>("api/customer");
        }
    }
}
