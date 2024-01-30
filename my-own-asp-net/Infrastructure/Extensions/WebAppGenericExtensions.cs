using my_own_asp_net.Infrastructure.Application;

namespace my_own_asp_net.Infrastructure.Extensions;

public static class WebAppGenericExtensions
{
    public static  void Map<T>(this WebApp app, string url) where T : IRequestHandler, new()
    {
        app.Map(url, new T());
    }
}