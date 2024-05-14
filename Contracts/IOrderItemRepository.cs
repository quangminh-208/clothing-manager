using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IOrderItemRepository : IRepositoryBase<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItems();
    }
}