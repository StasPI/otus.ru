using Abstraction;

namespace Implementation
{
   internal class DataConsoleWriter : IDataWriter
   {
      public virtual void Write(string text)
      {
         Console.WriteLine(text);
      }

      public virtual void Write(int number)
      {
         Console.WriteLine(number);
      }
   }
}