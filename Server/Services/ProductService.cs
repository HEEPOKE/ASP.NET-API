using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ProductService : Server.Interfaces.ProductInterface
    {

        public async Task<List<Product>> GetAllProduct()
        {
        
        }
        public async Task<Product?> GetProductById(int id)
        {

        }
        public async Task<List<Product>> AddProduct(Product Product)
        {

        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {

        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {

        }
    }
}