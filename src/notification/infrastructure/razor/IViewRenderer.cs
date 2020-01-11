using System.Threading.Tasks;

namespace Notification.Infrastructure.Razor
{
    public interface IViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
