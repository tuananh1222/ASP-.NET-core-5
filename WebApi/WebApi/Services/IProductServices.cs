using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        List<Product> GetAll();

        Product Get(int id);

        void Update(Product product);
        void Remove(int id);
        

    }
}
