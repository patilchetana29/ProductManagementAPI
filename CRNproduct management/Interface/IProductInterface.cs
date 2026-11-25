using CRNproduct.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Interface
{
    public interface IProductInterface
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
