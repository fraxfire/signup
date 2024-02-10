using System.Collections.Generic; // Assicurati di includere il namespace per List<Purchase>
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimaWeb.Models;

namespace PrimaWeb.Controllers
{
    public class PurchaseController : Controller
    {
        private List<Purchase> _cartItems;

        public PurchaseController()
        {
            _cartItems = new List<Purchase>();
    }

        // Altri metodi del controller PurchaseController...

        [HttpPost]
        public IActionResult AddToCart(Purchase purchase)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.NomeProdotto == purchase.NomeProdotto);

            if (existingItem != null)
            {
                existingItem.Quantita += purchase.Quantita;
            }
            else
            {
                _cartItems.Add(purchase);
            }

            return RedirectToAction("Cart");
        }

    }
}
