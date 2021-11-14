using System;
using System.Threading.Tasks;

namespace WebClient
{
   public class UseCases
   {
      int userGen;
      long userId;

      public async Task UseAsync()
      {
         Console.WriteLine("Введите число сколько покупателей должно быть сгенерировано:");
         userGen = Convert.ToInt32(Console.ReadLine());

         for(int i = 0; i < userGen; i++)
         {
            GetRandom getRandom = new GetRandom();
            string lastName = getRandom.RandomString();
            string firstName = getRandom.RandomString();
            CustomerModel customer = new CustomerModel(lastName, firstName);
            CustomerEndpoint requests = new CustomerEndpoint("https://localhost:5001/");
            await requests.PostAsync(customer);
         }

         while (true)
         {
            Console.WriteLine("Что бы получить информацию введите Id покупателя(введите 0 для выхода): ");
            userId = Convert.ToInt64(Console.ReadLine());
            if (userId == 0)
            {
               break;
            }
            else
            {
               CustomerModel customer = new CustomerModel();
               CustomerEndpoint requests = new CustomerEndpoint("https://localhost:5001/");
               await requests.GetAsync(userId);
            }
         }
      }
   }
}