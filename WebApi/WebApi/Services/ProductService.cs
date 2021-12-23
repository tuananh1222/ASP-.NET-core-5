using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Services
{
    public class ProductService: IProductServices
    {
       

        private List<Product> Products { get; }

        public ProductService()
        {
            Products = new List<Product>
            {
                new Product {Id = 1 , Name = "Bàn"}
            };
        }

    
        public Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);
       

        public void AddProduct(Product product)
        {
            product.Id = Products.Count() + 1;
            Products.Add(product);
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public void Update(Product product)
        {
            var index = Products.FindIndex(Product => Product.Id == product.Id);
            if (index == -1)
                return;

            Products[index].Name = product.Name;
        }

        public void Remove(int id)
        {
            var product = Get(id);
            if (product != null)
            {
                Products.Remove(product);
            }
            
        }
    }
}
