using Desafio_Final_Arquitetura_de_Software.Models.Entities;
using Desafio_Final_Arquitetura_de_Software.Models.Repositories;

namespace Desafio_Final_Arquitetura_de_Software.Models.Services
{
    public class ProductsService
    {
        private ProductsRepository productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await productsRepository.GetAllAsync();
        }

        public async Task<int> CountAllAsync()
        {
            return await productsRepository.CountAllAsync();
        }

        public async Task<IEnumerable<Products>> GetAllByNameAsync(string name)
        {
            return await productsRepository.GetAllByNameAsync(name);
        }

        public async Task<Products?> GetByIdAsync(int id)
        {
            return await productsRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Products products)
        {
            await productsRepository.CreateAsync(products);
        }

        public async Task UpdateAsync(Products products)
        {
            await productsRepository.UpdateAsync(products);
        }

        public async Task DeleteAsync(int id)
        {
            var products = await GetByIdAsync(id);
            if (products != null)
            {
                await productsRepository.DeleteAsync(products);
            }
        }
    }
}
