using System.Threading.Tasks;
using ASPDNC.Core.Http;

namespace ASPDNC.Core.Handler {
    public delegate Task RequestDelegate(HttpContext context);
}
