using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                ////await orderContext.Set<Order>().AddRangeAsync(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders() => new List<Order>
            {
                new()
                {
                    UserName = "kevinhayes",
                    TotalPrice = 350,
                    FirstName = "Kevin",
                    LastName = "Anderson",
                    EmailAddress = "kevinhayesanderson@gmail.com",
                    AddressLine = "Chennai",
                    Country = "India",
                   State="Chennai",
                   ZipCode="603103",

                   CardName = "VISA",
                   CardNumber = "13456789",
                   Expiration = "12/28",
                   CVV = "456",
                   PaymentMethod = 1,
                    CreatedDate = DateTime.Now,
                        CreatedBy = "kevin",
                       
                    LastModifiedDate = DateTime.Now,
                        LastModifiedBy = "kevin",
                }
            };
    }
}