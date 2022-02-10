using Abstractions;
using System.Diagnostics;

namespace Implementations
{
    public class SumArray : ISumArray
    {
        int _count;
        Random _random;
        Stopwatch _stopwatch;
        int[] _mainArray;
        long _sum;
        int _thread;
        Task<int>[] _taskArray;

        public SumArray(int count)
        {
            _count = count;
            _random = new Random();
            _stopwatch = new Stopwatch();
            _mainArray = new int[_count];
            _thread = Environment.ProcessorCount;
            for (int i = 0; i < _count; i++)
            {
                _mainArray[i] = _random.Next(1, 100);
            }
        }

        public void SumDefault()
        {
            _stopwatch.Restart();
            _sum = _mainArray.Sum();
            _stopwatch.Stop();
            MyWriter("Successively");
        }

        public void SumTask()
        {
            _stopwatch.Restart();
            IEnumerable<int[]> chanks = _mainArray.Chunk(_mainArray.Length / _thread);
            _taskArray = new Task<int>[chanks.Count()];
            int i = 0;
            foreach (int[] chank in chanks)
            {
                _taskArray[i] = Task.Run(() => chank.Sum());
                ++i;
            }
            Task.WaitAll(_taskArray);
            _sum = _taskArray.Sum(t => t.Result);
            _stopwatch.Stop();
            MyWriter($"Thread: {_thread}");
        }

        public void SumPLINQ()
        {
            _stopwatch.Restart();
            _sum = _mainArray.AsParallel().WithDegreeOfParallelism(_thread).Sum();
            _stopwatch.Stop();
            MyWriter("PLINQ");
        }

        private void MyWriter(string name)
        {
            Console.WriteLine($"Mas: {_count} | Sum: {_sum} | Time {_stopwatch.ElapsedMilliseconds} Milliseconds | {name}.");
        }
    }
}