using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;

using Microsoft.Extensions.DependencyInjection;

namespace TelnetServer_05_StartByConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start the server!");

            var serviceProvider = new ServiceCollection()
                .AddTransient<ITest, Test>()
                .AddSuperSocketNet()
                .BuildServiceProvider();

            var bootstrap = BootstrapFactory.CreateBootstrap(serviceProvider);
            // TODO rgr doppelt übergeben?
            if (!bootstrap.Initialize(serviceProvider))
            {
                Console.WriteLine("Failed to initialize!");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();

            Console.WriteLine("Start result: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();

            //Stop the appServer
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");            
        }
    }
}
