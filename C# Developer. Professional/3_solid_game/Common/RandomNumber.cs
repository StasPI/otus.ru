using Abstraction;

namespace Implementation
{
   public class RandomNumber : IRandomNumber
   {
      Random rnd = new Random();

      public int GetNumber(int rangeStart, int rangeEnd)
      {
         int value = rnd.Next(1, 10);
         return value;
      }
   }
}