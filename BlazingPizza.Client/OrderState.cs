﻿using System.Collections.Generic;

namespace BlazingPizza.Client
{
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }
        public Pizza ConfiguringPizza { get; private set; }
        public Order ActiveOrder { get; private set; } = new Order();

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            ShowingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            ActiveOrder.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ResetOrder()
        {
            ActiveOrder = new Order();
        }

        public void ReplaceOrder(Order order)
        {
            ActiveOrder = order;
        }

        public void RemoveConfiguredPizza(Pizza pizza)
        {
            ActiveOrder.Pizzas.Remove(pizza);
        }
    }
}
