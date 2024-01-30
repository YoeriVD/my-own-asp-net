namespace my_own_asp_net.Infrastructure.Application;

public class WebApp
{
    private readonly IDictionary<string, IRequestHandler> _handlers = new Dictionary<string, IRequestHandler>();

    public void Start()
    {
        Console.WriteLine("WebApp started");
    }

    public string ProcessRequest(string url)
    {
        Console.WriteLine($"Processing request for {url}");
        _handlers.TryGetValue(url, out var handler);
        if (handler != null) return handler.Handle();
        Console.WriteLine("404 Not found");
        return string.Empty;
    }
    
    public void Map<T>(string url) where T : IRequestHandler, new()
    {
        _handlers.Add(url, new T());
    }

    public void Map(string url, IRequestHandler handler)
    {
        _handlers.Add(url, handler);
    }

    public void Map(string url, Func<string> handler)
    {
        _handlers.Add(url, new LambdaHandler(handler));
    }
}