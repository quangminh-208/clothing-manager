using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> GetUserWithOrders(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}