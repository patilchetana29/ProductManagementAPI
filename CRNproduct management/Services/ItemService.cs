using CRNproduct.Domain;
using CRNproduct_management.DTO;
using CRNproduct_management.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Services
{
    public class ItemService:IItemService

    {
       
            private readonly IItemInterface _repository;

            public ItemService(IItemInterface repository)
            {
                _repository = repository;
            }

            public async Task<List<Item>> GetAllAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Item?> GetByIdAsync(int id)
            {
                return await _repository.GetByIdAsync(id);
            }

           
            public async Task<bool> DeleteAsync(int id)
            {
                var item = await _repository.GetByIdAsync(id);

                if (item == null)
                    return false;

                await _repository.DeleteAsync(item);

                return true;
            }

        public async Task<Item> CreateAsync(ItemCreateDTO dto)
        {
            var item = new Item
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
            return await _repository.CreateAsync(item);
        }

        public async Task<Item?> UpdateAsync(int id, ItemUpdateDTO dto)
        {
            var item = await _repository.GetByIdAsync(id);

            if (item == null)
                return null;

            item.Quantity = dto.Quantity;

            await _repository.UpdateAsync(item);

            return item;
        }
    }
    }

