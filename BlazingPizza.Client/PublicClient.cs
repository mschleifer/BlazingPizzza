using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class PublicClient
    {
        private readonly HttpClient httpClient;

        public PublicClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PizzaSpecial>> GetSpecials() =>
            await httpClient.GetFromJsonAsync<List<PizzaSpecial>>("specials");

        public async Task<List<Topping>> GetToppings() =>
            await httpClient.GetFromJsonAsync<List<Topping>>("toppings");

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PostAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}