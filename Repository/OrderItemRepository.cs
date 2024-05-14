using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            return await FindAll().OrderBy(ot => ot.Id).ToListAsync();
        }
    }
}