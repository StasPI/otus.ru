using System;
using System.Linq;

namespace WebClient
{
   public class GetRandom
   {
      Random rnd = new Random();

      public string RandomString()
      {
         return new String(Enumerable.Range(0, 10).Select(n => (Char)(rnd.Next(32, 127))).ToArray());
      }
   }
}