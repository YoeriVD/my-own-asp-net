namespace my_own_asp_net.Infrastructure.Application;

public class LambdaHandler(Func<string> handler) : IRequestHandler
{
    public string Handle() => handler();
}