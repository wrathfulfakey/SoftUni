namespace DemoApp
{
    using System;
    using SIS.HTTP;
    using System.Threading.Tasks;

   public class Program
    {
        public static async Task Main()
        {
            var httpServer = new HttpServer(80);

            await httpServer.StartAsync();
        }
    }
}
