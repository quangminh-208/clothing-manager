using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clothes_manager.Method;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace clothes_manager.Action
{
    public class UserAction : ActionBase<User>, IUserAction
    {
        public UserAction(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await FindAll().OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId)).FirstOrDefaultAsync();
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
