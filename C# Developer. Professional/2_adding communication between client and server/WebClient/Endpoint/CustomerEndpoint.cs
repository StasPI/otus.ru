using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient
{
   public class CustomerEndpoint
   {
      HttpClient _client;
      CustomerShow _show;
      readonly string _controller = "api/customers";

      public CustomerEndpoint(string Url)
      {
         _client = new HttpClient { BaseAddress = new Uri(Url) };
         _client.DefaultRequestHeaders.Accept.Clear();
         _client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));
         _show = new CustomerShow();
      }

      public async Task PostAsync(CustomerModel Object)
      {
         try
         {
            var response = await CreatePostAsync(Object);
            _show.ShowAllInfo(response);
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }

      public async Task<(HttpStatusCode statusCode, long? Id, string Firstname, string Lastname)> CreatePostAsync(CustomerModel Object)
      {
         HttpResponseMessage response = await _client.PostAsJsonAsync(_controller, Object);
         if (response.IsSuccessStatusCode)
         {
            CustomerModel customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            return (response.StatusCode, customer?.Id, customer?.Firstname, customer?.Lastname);
         }
         else
         {
            throw new Exception(response.ReasonPhrase);
         }
      }

      public async Task GetAsync(long Id)
      {
         try
         {
            var response = await CreateGetAsync(Id);
            _show.ShowAllInfo(response);
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }
      }

      public async Task<(HttpStatusCode statusCode, long? Id, string Firstname, string Lastname)> CreateGetAsync(long Id)
      {
         HttpResponseMessage response = await _client.GetAsync($"{_controller}/{Id}");
         if (response.IsSuccessStatusCode)
         {
            CustomerModel customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            return (response.StatusCode, customer?.Id, customer?.Firstname, customer?.Lastname);
         }
         else
         {
            throw new Exception(response.ReasonPhrase);
         }
      }
   }
}