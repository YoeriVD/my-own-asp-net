using my_own_asp_net.Infrastructure;
using my_own_asp_net.Infrastructure.Application;

namespace my_own_asp_net.Controllers;

public class TodoController
{
    [Route("/todo")]
    public string Get() => "Hello from TodoController GET";

    [Route("/todo/1")]
    public string GetFirst() => "Hello from TodoController GET first";
}