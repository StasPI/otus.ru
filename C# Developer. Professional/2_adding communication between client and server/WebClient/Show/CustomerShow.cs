using System;
using System.Net;

namespace WebClient
{
   internal class CustomerShow
   {
      public void ShowAllInfo((HttpStatusCode statusCode, long? Id, string Firstname, string Lastname) response)
      {
         Console.WriteLine($"StatusCode: {response.statusCode}| Id: {response.Id}| Firstname: {response.Firstname}| Lastname: {response.Lastname}");
      }
   }
}