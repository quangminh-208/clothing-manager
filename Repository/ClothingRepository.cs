using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class ClothingRepository : RepositoryBase<Clothing>, IClothingRepository
    {
        public ClothingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
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