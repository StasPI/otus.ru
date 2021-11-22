using Abstraction;
using GuessTheNumber;
using Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
   .ConfigureServices((context, services) =>
   {
      services.AddTransient<IDataConsole, DataConsoleGreen>();
      services.AddTransient<IRandomNumber, RandomNumber>();
   })
   .Build();

var service = ActivatorUtilities.CreateInstance<Game>(host.Services);
service.Execute();