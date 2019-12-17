using System.Threading.Tasks;
using ASPDNC.Core;
using ASPDNC.Core.Handler;
using ASPDNC.Core.Http;

namespace ASPDNC {
    class Program {
        static async Task Main(string[] args) {
            //////Console.WriteLine("Hello World!");

            //////HttpListener httpListener = new HttpListener();
            //////httpListener.Prefixes.Add("http://localhost:8000/");
            //////httpListener.Start();
            //////while (true) {
            //////    var context = await httpListener.GetContextAsync();
            //////    await context.Response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
            //////    context.Response.Close();
            //////}

            ////IServer server = new HttpListenerServer();
            ////async Task FooBar(HttpContext httpContext) {
            ////    await httpContext.Response.WriteAsync("FooBar");
            ////}
            ////await server.StartAsync(FooBar);
            //var application = new ApplicationBuilder()
            //    .Use(FooMiddleware)
            //    .Use(BarMiddleware)
            //    .Use(BazMiddleware)
            //    .Build();               

            //await server.StartAsync(application);

            await new WebHostBuilder()
                .UseHttpListener()
                .Configure(app => app
                    .Use(FooMiddleware)
                    .Use(BarMiddleware)
                    .Use(BazMiddleware))
                .Build()
                .StartAsync();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
            => async context => {
                await context.Response.WriteAsync("Foo=>");
                await next(context);

            };

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        => async context => {
            await context.Response.WriteAsync("Bar=>");
            await next(context);
        };

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        => context => context.Response.WriteAsync("Baz");

    }
}
