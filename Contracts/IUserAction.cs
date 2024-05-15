using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IUserAction : IActionBase<User>
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
