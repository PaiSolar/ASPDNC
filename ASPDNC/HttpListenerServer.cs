using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ASPDNC.Core;
using ASPDNC.Core.Handler;
using ASPDNC.Core.Http;

namespace ASPDNC {
    public class HttpListenerServer : IServer {
        private readonly HttpListener _listener;
        private readonly string[] _urls;

        public HttpListenerServer(params string[] urls) {
            _listener = new HttpListener();
            _urls = urls.Any() ? urls : new string[] { "http://localhost:8000/" };
        }

        public async Task StartAsync(RequestDelegate handler) {
            Array.ForEach(_urls, url => _listener.Prefixes.Add(url));
            _listener.Start();
            Console.WriteLine("Server started and is listening on: {0}", string.Join(';', _urls));
            while (true) {
                var listenerContext = await _listener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection()
                    .Set<IRequestFeature>(feature)
                    .Set<IResponseFeature>(feature);
                var httpContext = new HttpContext(features);
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }

    public static partial class Extensions {
        public static IWebHostBuilder UseHttpListener(this IWebHostBuilder builder, params string[] urls)
        => builder.UseServer(new HttpListenerServer(urls));
    }
}
