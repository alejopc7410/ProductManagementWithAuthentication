using AutoMapper;
using PMBLL;
using PMDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementSPA.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            ProductService productService = new ProductService();
            var productsList = productService.GetProducts();
            return Json(productsList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            ProductService productService = new ProductService();
            var products = productService.AddProduct(product);            
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetProduct(int productId)
        {
            ProductService productService = new ProductService();
            var product = productService.GetProduct(productId);
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult EditProduct(Product product)
        {
            ProductService productService = new ProductService();
            var productToUpdate = productService.EditProduct(product);
            return Json(productToUpdate, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            ProductService productService = new ProductService();
            if (productService.DeleteProduct(productId))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}