﻿using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders() => new List<Order>
            {
                new()
                {
                    UserName = "swn",
                    FirstName = "Kevin",
                    LastName = "Anderson",
                    EmailAddress = "kevinhayesanderson@gmail.com",
                    AddressLine = "Chennai",
                    Country = "India",
                    TotalPrice = 350
                }
            };
    }
}