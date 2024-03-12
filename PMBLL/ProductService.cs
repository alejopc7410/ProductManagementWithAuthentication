using PMDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            ProductRepository productRepository = new ProductRepository();
            return productRepository.GetProducts();
        }

        public bool AddProduct(Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            if(CheckObject(product))
                return productRepository.AddProduct(product);
            else 
                return false;
        }
        
        public Product GetProduct(int productId)
        {
            ProductRepository productRepository = new ProductRepository();
            return productRepository.GetProduct(productId);
        }
        
        public bool EditProduct(Product product)
        {
            ProductRepository productRepository = new ProductRepository();
            if (CheckObject(product))
                return productRepository.EditProduct(product);
            else
                return false;
        }
        
        public bool DeleteProduct(int productId)
        {
            ProductRepository productRepository = new ProductRepository();
            return productRepository.DeleteProduct(productId);
        }

        public bool CheckObject(Object objectToCheck)
        {
            PropertyInfo[] properties = objectToCheck.GetType().GetProperties();
            bool result = true;
            foreach (var property in properties)
            {
                var value = property.GetValue(objectToCheck);
                if (value == null)
                    result = false;
            }
            return result;
        }
    }
}
