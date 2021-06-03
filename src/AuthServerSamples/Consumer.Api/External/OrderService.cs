using System.Threading.Tasks;
using Consumer.Api.External.ApiClients.Order;
using Consumer.Api.External.Dto;

namespace Consumer.Api.External
{
    /// <inheritdoc cref="IOrderService"/>
    public class OrderService : IOrderService
    {
        private readonly IOrderApiClient _orderApiClient;

        /// <inheritdoc cref="OrderService"/>
        public OrderService(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }

        /// <inheritdoc />
        public Task<OrderDto> GetOrderById(long id)
        {
            return _orderApiClient.GetAsync<OrderDto>($"/api/order/{id}");
        }
    }
}