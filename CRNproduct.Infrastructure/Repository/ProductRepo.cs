using CRNproduct.Domain;
using CRNproduct_management.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct.Infrastructure.Repository
{
    public class ProductRepo:IProductInterface
    {
      
        private readonly ApplicationDbcontext _dbcontext;

        public ProductRepo(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbcontext.Product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbcontext.Product.FindAsync(id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _dbcontext.Product.Add(product);
            await _dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _dbcontext.Product.Update(product);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _dbcontext.Product.Remove(product);
            await _dbcontext.SaveChangesAsync();
        }

        public void AddItem(Item item)
        {
            try
            {
                _dbcontext.Item.Add(item);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }

    
}

   