namespace Implementation
{
   public class DataConsoleGreen : DataConsole
   {
      public override void Write(string text)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         base.Write(text);
         Console.ResetColor();
      }

      public override void Write(int number)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         base.Write(number);
         Console.ResetColor();
      }
   }
}