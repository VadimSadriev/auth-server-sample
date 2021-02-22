using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ordering.Api.Models;

namespace Ordering.Api.Application
{
    public class OrderService : IOrderService
    {
        private IDictionary<long, Order> _orders = new Dictionary<long, Order>();

        public Task<Order> GetOrderById(long id)
        {
            _orders.TryGetValue(id, out var order);

            return Task.FromResult(order);
        }

        public Task<long> CreateOrder(string name)
        {
            var lastOrder = _orders.Values.Last();

            var id = (lastOrder?.Id + 1) ?? 1;

            var order = new Order
            {
                Id = id,
                Name = name
            };
            
            _orders.Add(id, order);

            return Task.FromResult(id);
        }
    }
}