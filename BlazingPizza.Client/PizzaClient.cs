﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class PizzaClient
    {
        private readonly HttpClient httpClient;

        public PizzaClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PizzaSpecial>> GetSpecials() =>
            await httpClient.GetFromJsonAsync<List<PizzaSpecial>>("specials");

        public async Task<List<Topping>> GetToppings() =>
            await httpClient.GetFromJsonAsync<List<Topping>>("toppings");

        public async Task<IEnumerable<OrderWithStatus>> GetOrders() =>
            await httpClient.GetFromJsonAsync<IEnumerable<OrderWithStatus>>("orders");


        public async Task<OrderWithStatus> GetOrder(int orderId) =>
            await httpClient.GetFromJsonAsync<OrderWithStatus>($"orders/{orderId}");


        public async Task<int> PlaceOrder(Order order)
        {
            var response = await httpClient.PostAsJsonAsync("orders", order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PostAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}