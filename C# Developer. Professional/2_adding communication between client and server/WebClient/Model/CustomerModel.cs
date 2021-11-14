namespace WebClient
{
   public class CustomerModel
   {
      public long Id { get; init; }
      public string Firstname { get; init; }
      public string Lastname { get; init; }

      public CustomerModel()
      {
      }

      public CustomerModel(string firstName, string lastName)
      {
         Firstname = firstName;
         Lastname = lastName;
      }
   }
}