using CRNproduct.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Interface
{
    public interface IItemInterface
    {
        Task<List<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(int id);

        Task<Item> CreateAsync(Item item);

        Task UpdateAsync(Item item);

        Task DeleteAsync(Item item);
    }
}
