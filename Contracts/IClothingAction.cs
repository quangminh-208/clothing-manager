using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IClothingAction : IActionBase<Clothing>
    {
        Task<IEnumerable<Clothing>> GetAllClothings();

        Task<Clothing> GetClothingById(int clothingId);
        void CreateClothing(Clothing clothing);
        void UpdateClothing(Clothing clothing);
        void DeleteClothing(Clothing clothing);
    }
}
