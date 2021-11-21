using Abstraction;

namespace Implementation
{
   public class Settings : ISettings
   {
      private int numberOfAttempts;
      private int rangeStart;
      private int rangeEnd;

      public int NumberOfAttempts
      {
         get
         {
            return numberOfAttempts;
         }
         set
         {
            if (value <= 0)
            {
               numberOfAttempts = 1;
            }
            else
            {
               numberOfAttempts = value;
            }
         }
      }

      public int RangeStart
      {
         get
         {
            return rangeStart;
         }
         set
         {
            if (value <= 0)
            {
               rangeStart = 1;
            }
            else
            {
               rangeStart = value;
            }
         }
      }

      public int RangeEnd
      {
         get
         {
            return rangeEnd;
         }
         set
         {
            if (value <= 0)
            {
               rangeEnd = 1;
            }
            else
            {
               rangeEnd = value;
            }
         }
      }

   }
}