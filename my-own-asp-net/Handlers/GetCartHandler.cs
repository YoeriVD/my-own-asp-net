using my_own_asp_net.Infrastructure;
using my_own_asp_net.Infrastructure.Application;

namespace my_own_asp_net.Handlers;

public class GetCartHandler : IRequestHandler
{
    public string Handle()
    {
        return "Hello from cart";
    }
}