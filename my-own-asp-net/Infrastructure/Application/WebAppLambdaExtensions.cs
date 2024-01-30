namespace my_own_asp_net.Infrastructure.Application;

public static class WebAppLambdaExtensions
{
    public static void Map(this WebApp app, string url, Func<string> handler)
    {
        app.Map(url, new LambdaHandler(handler));
    }
}