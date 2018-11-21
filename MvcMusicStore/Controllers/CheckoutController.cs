using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MusicStoreDB storeDB = new MusicStoreDB();
        const string PromoCode = "FREE";

        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(Order order)
        {
            if (ModelState.IsValid)
            {
                string promoCode = HttpContext.Request.Form["PromoCode"];
                if (string.Equals(promoCode,PromoCode,StringComparison.OrdinalIgnoreCase)==false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { Id = order.OrderId });
                }
            }
            else
            {
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            // this your order?
            bool valid = storeDB.Orders.Any(order =>
              (order.OrderId == id) && (order.Username == User.Identity.Name));

            if (valid)
                return View(id);
            else
                return View("Error");
        }
    }
}