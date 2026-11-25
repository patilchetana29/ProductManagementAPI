using CRNproduct.Domain;
using CRNproduct_management.DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace CRNproduct_management.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(ProductCreateDto dto);

        Task<Product?> UpdateAsync(int id, ProductUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
