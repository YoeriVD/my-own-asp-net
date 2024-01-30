namespace my_own_asp_net.Infrastructure.Application;

public static class WebAppGenericExtensions
{
    public static  void Map<T>(this WebApp app, string url) where T : IRequestHandler, new()
    {
        app.Map(url, new T());
    }
}