﻿namespace DemoApp
{
    using System.Threading.Tasks;
    using SIS.MvcFramework;

    public class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}
