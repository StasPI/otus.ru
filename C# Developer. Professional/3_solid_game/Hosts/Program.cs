using GuessTheNumber;
using Implementation;
using Microsoft.Extensions.Configuration;

Settings settings = new Settings();
DataConsoleGreen dataConsole = new DataConsoleGreen();
RandomNumber randomNumber = new RandomNumber();

GetSettings(settings);

Game game = new Game(settings, randomNumber, dataConsole);
game.Execute();

void GetSettings(Settings settings)
{
   IConfigurationBuilder builder = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

   IConfigurationRoot configuration = builder.Build();
   settings.NumberOfAttempts = int.Parse(configuration["NumberOfAttempts"]);
   settings.RangeStart = int.Parse(configuration["RangeStart"]);
   settings.RangeEnd = int.Parse(configuration["RangeEnd"]);
}