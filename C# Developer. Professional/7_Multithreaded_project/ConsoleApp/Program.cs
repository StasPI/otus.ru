using Abstractions;
using Implementations;

ISumArray sumArray;

List<int> run = new List<int>() { 100000 , 1000000, 10000000 };
foreach (int i in run)
{
    sumArray = new SumArray(i);
    sumArray.SumDefault();
    sumArray.SumTask();
    sumArray.SumPLINQ();
}