using CRNproduct.Domain;
using CRNproduct_management.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Interface
{
    public interface IItemService
    {
        Task<List<Item>> GetAllAsync();

        Task<Item?> GetByIdAsync(int id);

        Task<Item> CreateAsync(ItemCreateDTO dto);

        Task<Item?> UpdateAsync(int id, ItemUpdateDTO dto);

        Task<bool> DeleteAsync(int id);
    }
}
