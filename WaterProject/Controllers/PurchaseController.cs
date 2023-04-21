using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Controllers
{
    public class PurchaseController : Controller
    {
        // Define private properties for the Purchase Repository and Basket
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }

        // Constructor for the PurchaseController that takes in a Purchase Repository and Basket
        public PurchaseController(IPurchaseRepository temp, Basket b)
        {
            repo = temp;  // Assign the Purchase Repository to the repo property
            basket = b;  // Assign the Basket to the basket property
        }

        // Get request for the Checkout action
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());  // Render the Checkout view with a new instance of the Purchase model
        }

        // Post request for the Checkout action
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            // If the cart is empty, add a validation error to the model state
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            // If the model state is valid, save the purchase and clear the cart, then redirect to the PurchaseCompleted page
            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();  // Assign the items in the cart to the Lines property of the Purchase model
                repo.SavePurchase(purchase);  // Save the purchase to the repository
                basket.ClearBasket();  // Clear the contents of the cart
                return RedirectToPage("/PurchaseCompleted");  // Redirect to the PurchaseCompleted page
            }
            else  // If the model state is not valid, return the Checkout view with the current Purchase model instance
            {
                return View();
            }
        }
    }
}
