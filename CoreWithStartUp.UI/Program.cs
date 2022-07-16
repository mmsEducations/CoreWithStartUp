using CoreWithStartUp.UI;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

Console.WriteLine("Hello, World!");

WebHost.CreateDefaultBuilder(args)
       .UseStartup<Startup>()
       .Build()
       .Run();
       