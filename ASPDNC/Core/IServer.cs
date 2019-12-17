using ASPDNC.Core.Handler;
using System.Threading.Tasks;

namespace ASPDNC.Core {
    public interface IServer {
        Task StartAsync(RequestDelegate handler);
    }
}
