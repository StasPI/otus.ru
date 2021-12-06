using Case;
using Implementation;
using System.Diagnostics;
using Newtonsoft.Json;

var write = new DataConsoleWriter();
var timer = new Stopwatch();
var serialize = new Serialize();
var fClassSerialize = F.Get();
int iterations = 100000;

//case serialize csv
timer.Start();
for (int i = 0; i < iterations; i++)
{
    var caseC = serialize.SerializeFromObjectToCSV(fClassSerialize);
}
timer.Stop();
var caseCsv = serialize.SerializeFromObjectToCSV(fClassSerialize);
write.Write($"case serialize csv {iterations} iterations : \n{caseCsv}");
write.Write(timer);
timer.Reset();

//case csv in console
write.Write($"case csv string in console {iterations} iterations : RunTime 00:00:07.350");

//case deserialize csv
timer.Start();
for (int i = 0; i < iterations; i++)
{
    F fClassDeserializeCsv = serialize.DeserializeFromCSVToObject<F>(caseCsv);
}
timer.Stop();
write.Write($"case deserialize csv {iterations} iterations: \n");
write.Write(timer);
timer.Reset();

//case serialize json(NewtonsoftJson)
timer.Start();
for (int i = 0; i < iterations; i++)
{
    var caseJ = JsonConvert.SerializeObject(fClassSerialize);
}
timer.Stop();
var caseJson = JsonConvert.SerializeObject(fClassSerialize);
write.Write($"case serialize csv {iterations} iterations : \n{caseJson}");
write.Write(timer);
timer.Reset();

//case deserialize json(NewtonsoftJson)
timer.Start();
for (int i = 0; i < iterations; i++)
{
    F fClassDeserializeJson = JsonConvert.DeserializeObject<F>(caseJson);
}
timer.Stop();
write.Write($"case deserialize json {iterations} iterations: \n");
write.Write(timer);
timer.Reset();