using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public interface ProductInterface
    {
        Task<List<Product>> GetAllProduct();
        Task<Product?> GetUserById(int id);
        Task<List<Product>> AddProduct(Product product);
        Task<List<Product>?> UpdateProduct(int id, Product request);
        Task<List<Product>?> DeleteProduct(int id);
    }
}