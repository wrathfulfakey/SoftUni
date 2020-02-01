namespace DemoApp
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SIS.HTTP;

    public class Program
    {
        public static async Task Main()
        {
            var routeTable = new List<Route>
            {
                new Route(HttpMethodType.Get, "/", Index),
                new Route(HttpMethodType.Get, "/users/login", Login),
                new Route(HttpMethodType.Post, "/users/login", DoLogin),
                new Route(HttpMethodType.Get, "/Contact", Contact),
                new Route(HttpMethodType.Get, "/favicon.ico", FavIcon)
            };
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        public static HttpResponse Index(HttpRequest request)
        {
            var content = "<h1>Home page</h1><img src='/images/img.jpeg' />";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));
            return response;
        }

        public static HttpResponse Contact(HttpRequest request)
        {
            var content = "<h1>Contact page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            return response;
        }

        public static HttpResponse FavIcon(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public static HttpResponse Login(HttpRequest request)
        {
            var content = "<h1>Login page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));
            return response;
        }

        public static HttpResponse DoLogin(HttpRequest request)
        {
            var content = "<h1>Login page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);
            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));
            return response;
        }
    }
}
