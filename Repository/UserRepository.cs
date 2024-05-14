using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await FindAll().OrderBy(u => u.FirstName).ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserWithOrders(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId))
                .Include(od => od.UserOrders)
                .FirstOrDefaultAsync();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }
    }
}