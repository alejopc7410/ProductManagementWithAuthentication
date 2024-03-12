using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            ProdManagSPAEntities PMEnt = new ProdManagSPAEntities();
            var productsList = PMEnt.Products.ToList();
            return productsList;
        }

        public bool AddProduct(Product product)
        {
            ProdManagSPAEntities PMEnt = new ProdManagSPAEntities();
            if(product != null)
            {
                PMEnt.Products.Add(product);
                PMEnt.SaveChanges();
                return true;
            }
            return false;
        }
        
        public Product GetProduct(int productId)
        {
            ProdManagSPAEntities PMEnt = new ProdManagSPAEntities();
            var product = PMEnt.Products.FirstOrDefault(x => x.ProductID == productId);
            return product;
        }
        
        public bool EditProduct(Product product)
        {
            ProdManagSPAEntities PMEnt = new ProdManagSPAEntities();
            var productToUpdate = PMEnt.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if(productToUpdate != null)
            {
                Mapper.Map(product, productToUpdate);
                PMEnt.SaveChanges();
                return true;
            }
            return false;
        }
        
        public bool DeleteProduct(int productId)
        {
            ProdManagSPAEntities PMEnt = new ProdManagSPAEntities();
            var product = PMEnt.Products.FirstOrDefault(x => x.ProductID == productId);
            if(product != null)
            {
                PMEnt.Products.Remove(product);
                PMEnt.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
