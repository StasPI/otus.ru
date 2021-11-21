namespace Abstraction
{
   public interface ISettings
   {
      public int NumberOfAttempts { get; set; }
      public int RangeEnd { get; set; }
      public int RangeStart { get; set; }
   }
}