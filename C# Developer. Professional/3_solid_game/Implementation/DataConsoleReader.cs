using Abstraction;

namespace Implementation
{
   internal class DataConsoleReader : IDataReader
   {
      public virtual int ReadInt()
      {
         return int.Parse(Console.ReadLine());
      }

      public virtual string ReadString()
      {
         return Console.ReadLine();
      }
   }
}