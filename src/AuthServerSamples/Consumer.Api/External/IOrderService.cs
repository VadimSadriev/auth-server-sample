using System.Threading.Tasks;
using Consumer.Api.External.Dto;

namespace Consumer.Api.External
{
    /// <summary>
    /// Service to work with orders
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Returns order by id
        /// </summary>
        Task<OrderDto> GetOrderById(long id);
    }
}