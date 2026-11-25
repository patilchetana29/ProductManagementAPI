using System;
using System.Collections.Generic;
using System.Text;


using CRNproduct.Domain;
using CRNproduct_management.DTO;
using CRNproduct_management.Interface;
using global::CRNproduct_management.DTO;
using global::CRNproduct_management.Interface;

    namespace CRNproduct_management.Services
    {
        public class ProductService : IProductService
        {
            private readonly IProductInterface _repository;

            public ProductService(IProductInterface repository)
            {
                _repository = repository;
            }

            // Get All Products
            public async Task<List<Product>> GetAllAsync()
            {
                return await _repository.GetAllAsync();
            }

            // Get Product By Id
            public async Task<Product?> GetByIdAsync(int id)
            {
                return await _repository.GetByIdAsync(id);
            }

            // Create Product
            public async Task<Product> CreateAsync(ProductCreateDto dto)
            {
                var product = new Product
                {
                    ProductName = dto.ProductName,
                    CreatedBy = dto.CreatedBy,
                    CreatedOn = DateTime.Now
                };

                return await _repository.CreateAsync(product);
            }

            // Update Product
            public async Task<Product?> UpdateAsync(int id, ProductUpdateDto dto)
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                    return null;

                product.ProductName = dto.ProductName;
                product.ModifiedBy = dto.ModifiedBy;
                product.ModifiedOn = DateTime.Now;

                await _repository.UpdateAsync(product);

                return product;
            }

            // Delete Product
            public async Task<bool> DeleteAsync(int id)
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                    return false;

                await _repository.DeleteAsync(product);

                return true;
            }
        }
    }
