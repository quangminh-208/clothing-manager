using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Contracts
{
    public interface IUserOrderRepository : IRepositoryBase<UserOrder>
    {
        Task<IEnumerable<UserOrder>> GetAllUserOrders();
        Task<UserOrder> GetOrderWithItems(int orderId);
    }
}