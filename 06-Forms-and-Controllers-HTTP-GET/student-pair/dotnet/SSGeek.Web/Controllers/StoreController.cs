using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Extensions;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {

        private IProductDAO dao;

        public StoreController(IProductDAO dao)
        {
            this.dao = dao;
        }


        public IActionResult Index()
        {
            var products = dao.GetProducts();
            return View(products);
        }

        public IActionResult Detail(Product product)
        {
            var detailProduct = dao.GetProduct(product.Id);
            return View(detailProduct);
        }

        [HttpPost]

        public IActionResult AddToCart(Product product, int quantity)
        {
            product = dao.GetProduct(product.Id);

            ShoppingCart shoppingCart = GetActiveShoppingCart(); ;

            shoppingCart.AddToCart(product, quantity);

            SaveActiveShoppingCart(shoppingCart);

            return RedirectToAction("ViewCart");

        }

        public IActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = HttpContext.Session.Get<ShoppingCart>("Shopping_Cart");

            if (cart == null)
            {
                cart = new ShoppingCart();
                SaveActiveShoppingCart(cart);
            }
            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            HttpContext.Session.Set("Shopping_Cart", cart);
        }
    }
}