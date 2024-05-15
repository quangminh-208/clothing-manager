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
    public class ClothingAction : ActionBase<Clothing>, IClothingAction
    {
        public ClothingAction(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<Clothing>> GetAllClothings()
        {
            return await FindAll().OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Clothing> GetClothingById(int clothingId)
        {
            return await FindByCondition(clothing => clothing.Id.Equals(clothingId)).FirstOrDefaultAsync();
        }

        public void CreateClothing(Clothing clothing)
        {
            Create(clothing);
        }

        public void UpdateClothing(Clothing clothing)
        {
            Update(clothing);
        }

        public void DeleteClothing(Clothing clothing)
        {
            Delete(clothing);
        }

    }
}
