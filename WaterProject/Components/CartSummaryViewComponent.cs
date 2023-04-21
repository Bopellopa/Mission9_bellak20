using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Components
{
    // This class represents a view component that displays a summary of items in the cart.
    public class CartSummaryViewComponent : ViewComponent
    {
        // Private field to hold the cart service.
        private Basket cart;

        // Constructor that takes a cart service as a parameter.
        public CartSummaryViewComponent(Basket cartService)
        {
            // Assign the cart service to the private field.
            cart = cartService;
        }

        // This method is called when the view component is invoked.
        public IViewComponentResult Invoke()
        {
            // Pass the cart service to the view and return the result.
            return View(cart);
        }
    }
}

