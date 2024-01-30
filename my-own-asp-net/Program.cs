using my_own_asp_net.Controllers;
using my_own_asp_net.Handlers;
using my_own_asp_net.Infrastructure.Application;

Console.WriteLine("Hello, World!");

WebApp app = new();


app.Map("/blabla", () => "Hello from blabla");
app.Map("/hello", () => "Hello from hello");

app.Map("/user", new GetUserHandler());

app.Map<GetCartHandler>("/cart");

app.AddController<TodoController>();

app.Start();