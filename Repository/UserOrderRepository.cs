using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserOrderRepository : RepositoryBase<UserOrder>, IUserOrderRepository
    {
        public UserOrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<UserOrder>> GetAllUserOrders()
        {
            return await FindAll().OrderBy(uo => uo.Id).ToListAsync();
        }

        public async Task<UserOrder> GetOrderWithItems(int orderId)
        {
            return await FindByCondition(user => user.Id.Equals(orderId))
                .Include(od => od.OrderItems)
                .FirstOrDefaultAsync();
        }
    }
}