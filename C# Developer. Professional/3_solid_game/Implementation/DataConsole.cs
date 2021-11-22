using Abstraction;

namespace Implementation
{
   public class DataConsole : IDataConsole
   {
      public virtual int ReadInt()
      {
         return int.Parse(Console.ReadLine());
      }

      public virtual string ReadString()
      {
         return Console.ReadLine();
      }

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