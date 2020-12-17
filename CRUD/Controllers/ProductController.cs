using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> Products = new List<Product>();

        public IActionResult Index()
        {
            return View(Products);
        }
        #region Create New Product
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //Add to List
            Products.Add(product);

            //Ridirect to action index to show list

            return RedirectToAction("Index");
        }
        #endregion

        #region Edit Product
        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == id);
            if(product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index", "Product");
            // return RedirectToAction(actionName: "Index",controllerName:"Product");ghdghdghdghdgh
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var _product = Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.UnitPrice = product.UnitPrice;
                _product.Quantity = product.Quantity;
                
            }
            return RedirectToAction("Index", "Product");
        }
        #endregion
        #region Delete Product
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                Products.Remove(product);

            }
            return RedirectToAction("Index");
        }
        
        #endregion
    }
}
