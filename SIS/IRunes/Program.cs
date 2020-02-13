using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace IRunes
{
    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}
