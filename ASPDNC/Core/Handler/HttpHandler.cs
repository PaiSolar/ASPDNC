using System.Threading.Tasks;
using ASPDNC.Core.Http;

//
// 该类用RequestDelegate取代
//
namespace ASPDNC.Core {

    public interface IHttpHandler {
        Task Handle(HttpContext context);
    }

    public class HttpHandler {
        public Task Handle(HttpContext context) {
            return null;
        }
    }
}
