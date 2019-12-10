using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ASPDNC {
    class Program {
        static async Task Main(string[] args) {
            //Console.WriteLine("Hello World!");

            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8000/");
            httpListener.Start();
            while (true) {
                var context = await httpListener.GetContextAsync();
                await context.Response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes("Hello World!"));
                context.Response.Close();
            }
        }
    }
}
