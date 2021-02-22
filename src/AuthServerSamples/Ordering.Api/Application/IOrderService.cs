using System.Threading.Tasks;
using Ordering.Api.Models;

namespace Ordering.Api.Application
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(long id);

        Task<long> CreateOrder(string name);
    }
}