using CRNproduct.Domain;
using CRNproduct_management.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct.Infrastructure.Repository
{
    public class ItemRepo : IItemInterface
    {
        private readonly ApplicationDbcontext _dbcontext;

        public ItemRepo(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Item> CreateAsync(Item item)
        {
            try
            {
                _dbcontext.Item.Add(item);
                await _dbcontext.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Item item)
        {
            _dbcontext.Item.Remove(item);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {

            return await _dbcontext.Item.ToListAsync();

        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _dbcontext.Item.FindAsync(id);
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Item item)
        {
            _dbcontext.Item.Update(item);
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
