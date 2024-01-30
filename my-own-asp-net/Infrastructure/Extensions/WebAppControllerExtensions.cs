using my_own_asp_net.Infrastructure.Application;

namespace my_own_asp_net.Infrastructure.Extensions;

public static class WebAppControllerExtensions
{
    public static void AddController<TController>(this WebApp app) where TController : class
    {
        var controllerType = typeof(TController);
        var methods = controllerType.GetMethods();
        var methodsWithRoute = methods.Where(m => m.GetCustomAttributes(typeof(RouteAttribute), false).Length != 0);
        foreach (var methodInfo in methodsWithRoute)
        {
            var attribute = methodInfo.GetCustomAttributes(typeof(RouteAttribute), false).First() as RouteAttribute;
            var route = attribute!.Route; // already checked for null
            app.Map(route, new LambdaHandler(() =>
            {
                var controller = Activator.CreateInstance(controllerType);
                var result = methodInfo.Invoke(controller, null) as string;
                return result!;
            }));
        }
    }
}

public class RouteAttribute(string route) : Attribute
{
    public string Route { get; } = route;
}