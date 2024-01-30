// See https://aka.ms/new-console-template for more information

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

var isRunning = true;
while (isRunning)
{
    Console.Write("Enter URL:");
    var getUrl = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(getUrl)) continue;
    if (getUrl == "q")
    {
        isRunning = false;
        continue;
    }


    var response = app.ProcessRequest(getUrl);
    Console.WriteLine(response);
}