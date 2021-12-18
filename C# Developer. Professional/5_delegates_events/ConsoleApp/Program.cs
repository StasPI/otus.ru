using Implementation;

//case Func
List<Nubmer> test = new List<Nubmer>() { new Nubmer(11), new Nubmer(22), new Nubmer(33), new Nubmer(9) };
Console.WriteLine($"case Func");
Console.WriteLine($"Max value: {test.GetMax<Nubmer>(item => item.Value)}");

Console.WriteLine(new string('-', 80));

//case File
string dirName = AppDomain.CurrentDomain.BaseDirectory;
Console.WriteLine($"case File");
FilesSearch filesSearch = new FilesSearch(dirName);

Console.WriteLine($"+= StartMessage");
filesSearch.FileFound += Message.Start;
filesSearch.Start();

Console.WriteLine($"+= StopMessage");
filesSearch.FileFound += Message.Stop;
filesSearch.Start();

Console.WriteLine($"Only start");
filesSearch.Start();