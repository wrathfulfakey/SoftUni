namespace DemoApp
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.HTTP.Response;
    using System.IO;

    public class Program
    {
        public static async Task Main()
        {
            var routeTable = new List<Route>
            {
                new Route(HttpMethodType.Get, "/", Index),
                new Route(HttpMethodType.Get, "/users/login", Login),
                new Route(HttpMethodType.Post, "/users/login", DoLogin),
                new Route(HttpMethodType.Get, "/contact", Contact),
                new Route(HttpMethodType.Get, "/favicon.ico", FavIcon)
            };
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        public static HttpResponse Contact(HttpRequest request)
        {
            return new HtmlResponse("<h1>contact</h1>");
        }

        public static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }

        // Headers => html table list of all Headers

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";
            return new HtmlResponse($"<h1>Hello, {username}! You are now on our Home Page.</h1><a href='/users/login'>Login Now</a>");
        }

        public static HttpResponse Login(HttpRequest request)
        {
            request.SessionData["Username"] = "Pesho";
            return new HtmlResponse("<h1>Login Page</h1><a href='/'>Home Page</a>");
        }

        public static HttpResponse DoLogin(HttpRequest request)
        {
            return new HtmlResponse("<h1>Login Page form</h1>");  
        }
    }
}
