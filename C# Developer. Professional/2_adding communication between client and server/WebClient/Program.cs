using System;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
   static class Program
   {
      static async Task Main(string[] args)
      {
         EncodingConsole();
         UseCases useCases = new UseCases();
         await useCases.UseAsync();
         Console.ReadKey();
      }  

      public static void EncodingConsole()
      {
         Console.InputEncoding = Encoding.Unicode;
         Console.OutputEncoding = Encoding.Unicode;
      }
   }
}